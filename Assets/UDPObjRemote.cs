/*
-----------------------
UDP Object
-----------------------
Code pulled from here and modified
 [url]http://msdn.microsoft.com/de-de/library/bb979228.aspx#ID0E3BAC[/url]

Unity3D to MATLAB UDP communication 

Modified by: Sandra Fang 
2016
*/
using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

public class UDPObjRemote : MonoBehaviour
{

	//local host
	public string IP = "192.168.10.11";

	//Ports
	public int portLocal = 51000;
	public int portRemote = 51001;

	// Create necessary UdpClient objects
	UdpClient client;
	IPEndPoint remoteEndPoint;

	// Receiving Thread
	Thread receiveThread;
	// Message to be sent
	string strMessageSend = "";

	// info strings
	public string lastReceivedUDPPacket = "";
	public string allReceivedUDPPackets = "";
	public string tenPacket = "";
	public float inputNumber = 0.0f;
	public static string inputString = "Nothing";
	public static float outputNum = 0f;
	public static float fbNum = 0f;
	public static float leftNum = 0f;
	public static float rightNum = 0f;
	public static float topNum = 0f;
	public static float bottomNum = 0f;
	// clear this from time to time!

	// start from Unity3d
	public void Start ()
	{
		init ();
	}

	// OnGUI
	void OnGUI ()
	{
		Rect rectObj = new Rect (40, 10, 200, 400);
		GUIStyle style = new GUIStyle ();
		style.alignment = TextAnchor.UpperLeft;
//		GUI.Box (rectObj, "# UDP Object Receive\n192.168.10.11:" + portLocal + "\n"
//			+ "\nLast Packet: \n" + lastReceivedUDPPacket + "\nLast string: \n" + inputString + "\nlast Number: \n" + 
//			inputNumber + "\n\nAll Messages: \n" + allReceivedUDPPackets
//			, style);

		strMessageSend = GUI.TextField (new Rect (40, 420, 140, 20), strMessageSend);
		if (GUI.Button (new Rect (190, 420, 40, 20), "send")) {
			sendData (strMessageSend + "\n");
		}  

	}

	// Initialization code
	private void init ()
	{
		// Initialize (seen in comments window)
		print ("UDP Object init()");

		// Create remote endpoint (to Matlab) 
		remoteEndPoint = new IPEndPoint (IPAddress.Parse (IP), portRemote);

		// Create local client
		client = new UdpClient (portLocal);

		// local endpoint define (where messages are received)
		// Create a new thread for reception of incoming messages
		receiveThread = new Thread (
			new ThreadStart (ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start ();
	}

	// Receive data, update packets received
	private  void ReceiveData ()
	{
		while (true) {

			try {
				IPEndPoint anyIP = new IPEndPoint (IPAddress.Any, 0);
				byte[] data = client.Receive (ref anyIP);
				List<string> lastTenPacket = new List<string>();
				string text = Encoding.UTF8.GetString (data);
				string tmpPacket = "";
				tenPacket = "";
				print(">> " + text);
				lastReceivedUDPPacket = text;
				tmpPacket = text;
				lastTenPacket.Add(text);
				if (lastTenPacket.Count >= 20)
					lastTenPacket.RemoveAt(0);
				foreach (string s in lastTenPacket) {
					tenPacket += s;
				}
				Parsing(tmpPacket); 
				tmpPacket = "";
				allReceivedUDPPackets = allReceivedUDPPackets + text;
				//allReceivedUDPPackets = allReceivedUDPPackets + " Times\n";

			} catch (Exception err) {
				print (err.ToString ());
			}
		}
	}

	// Send data
	private void sendData (string message)
	{
		try {
			byte[] data = Encoding.UTF8.GetBytes (message);
			client.Send (data, data.Length, remoteEndPoint);

		} catch (Exception err) {
			print (err.ToString ());
		}
	}

	// getLatestUDPPacket, clears all previous packets
	public string getLatestUDPPacket ()
	{
		allReceivedUDPPackets = "";
		return lastReceivedUDPPacket;
	}

	//Prevent crashes - close clients and threads properly!
	void OnDisable ()
	{ 
		if (receiveThread != null)
			receiveThread.Abort (); 

		client.Close ();
	}

	private void Parsing(string input)
	{
		string type = "";
		float num = 0.0f;
		var split = input.Split(' ');
		//print(split.Length);
		if (split.Length == 2)
		{
			type = split[0];
			//print("Parse");
			num = float.Parse(split[1]);
		}

		inputString = type;
		if (type == "Feedback")
			fbNum = num;
		else if (type == "SignalLeft")
			leftNum = num;
		else if (type == "SignalRight")
			rightNum = num;
		else if (type == "SignalTop")
			topNum = num;
		else if (type == "SignalBottom")
			bottomNum = num;
	}
}
