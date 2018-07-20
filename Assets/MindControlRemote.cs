using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MindControlRemote : MonoBehaviour
{

	Rigidbody rb;
	public Vector3 COM = new Vector3(0, 0, 0);

	public int wc_Torque_Length;
	public int wc_decelerationSpeed_Length;

	public float enginePower;
	public float steerAngle;
	public float m_Brake = 1000f;
	public float m_DecelerationSpeed = 1000f;
	public float currentspeed;
	public float m_Speed;
	public float m_Magnitude;

	public bool BrakeAllowed;

	public WheelCollider[] wheels;
	public Transform[] visualWheels;

	public Text speedText;



	public float Speed()
	{
		return wheels[2].radius * wheels[2].rpm * 60 / 1000  * Mathf.PI;
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = COM;
	}

	void Update()
	{
		float feedBackNum = UDPObjRemote.fbNum;
		float topSignalNum = UDPObjRemote.topNum;
		float bottomSignalNum = UDPObjRemote.bottomNum;
		float leftSignalNum = UDPObjRemote.leftNum;
		float rightSignalNum = UDPObjRemote.rightNum;
		string InputSignalFix = UDPObjRemote.inputString;


		if (feedBackNum == 1 && (topSignalNum != 0 || bottomSignalNum != 0 || leftSignalNum != 0 || rightSignalNum != 0 )) {
			print ("topSignalNum " + topSignalNum);
			print ("bottomSignalNum " + bottomSignalNum);
			print ("leftSignalNum " + leftSignalNum);
			print ("rightSignalNum " + rightSignalNum);
			if (topSignalNum > 0)
				ForWard(topSignalNum);
			else if (bottomSignalNum > 0)
				BackWard(bottomSignalNum);
			else if (leftSignalNum > 0)
				MoveLeft(leftSignalNum);
			else if (rightSignalNum > 0)
				MoveRight(rightSignalNum);			
		}
		else if (feedBackNum == 1 && topSignalNum == 0 && bottomSignalNum == 0 && leftSignalNum == 0 && rightSignalNum == 0) {
			Break();
		}
		else if (feedBackNum == 0) {
			Break();
		}

		if (speedText != null)
			speedText.text = "Speed: " + Speed().ToString("f0") + " km/h";
	}

	private void FixedUpdate()
	{
		for (int i = 0; i < wheels.Length; i++)
		{
			Vector3 pos;
			Quaternion rot;
			wheels[i].GetWorldPose(out pos, out rot);
			visualWheels[i].position = pos;
			visualWheels[i].rotation = rot;
		}



	}

	private void ForWard(float ratio)
	{
		print("moving car forward");
		wheels [0].steerAngle = 0;
		wheels [2].steerAngle = 0;
		wheels[0].brakeTorque = 0;
		wheels[1].brakeTorque = 0;
		wheels[2].brakeTorque = 0;
		wheels[3].brakeTorque = 0;
		wheels[1].motorTorque = ratio * enginePower;
		wheels[3].motorTorque = ratio * enginePower;
		wheels[0].motorTorque = ratio * enginePower;
		wheels[2].motorTorque = ratio * enginePower;

	}

	private void BackWard(float ratio)
	{
		print("moving the car back");
		wheels [0].steerAngle = 0;
		wheels [2].steerAngle = 0;
		wheels[0].brakeTorque = 0;
		wheels[1].brakeTorque = 0;
		wheels[2].brakeTorque = 0;
		wheels[3].brakeTorque = 0;
		wheels[1].motorTorque = ratio * enginePower * -1;
		wheels[3].motorTorque = ratio * enginePower * -1;
		wheels[0].motorTorque = ratio * enginePower * -1;
		wheels[2].motorTorque = ratio * enginePower * -1;

	}

	private void MoveLeft(float ratio)
	{
		print("moving the car left");
		wheels[0].steerAngle = -1 * steerAngle;
		wheels[2].steerAngle = -1 * steerAngle;
		wheels[0].brakeTorque = 0;
		wheels[1].brakeTorque = 0;
		wheels[2].brakeTorque = 0;
		wheels[3].brakeTorque = 0;
		wheels[1].motorTorque = ratio * enginePower;
		wheels[3].motorTorque = ratio * enginePower;
		wheels[0].motorTorque = ratio * enginePower;
		wheels[2].motorTorque = ratio * enginePower;
	}

	private void MoveRight(float ratio)
	{
		print("moving the car right");
		wheels[0].steerAngle = 1 * steerAngle;
		wheels[2].steerAngle = 1 * steerAngle;
		wheels[0].brakeTorque = 0;
		wheels[1].brakeTorque = 0;
		wheels[2].brakeTorque = 0;
		wheels[3].brakeTorque = 0;
		wheels[1].motorTorque = ratio * enginePower;
		wheels[3].motorTorque = ratio * enginePower;
		wheels[0].motorTorque = ratio * enginePower;
		wheels[2].motorTorque = ratio * enginePower;
	}

	private void DecelerationSpeed()
	{
		if (!BrakeAllowed && Input.GetButton("Vertical") == false)
		{
			for (int i = 0; i < wc_decelerationSpeed_Length; i++)
			{
				wheels[i].brakeTorque = m_DecelerationSpeed;
				wheels[i].motorTorque = 0;
			}
		}
	}

	private void Break(){
		print ("break");
		wheels[0].motorTorque = 0;
		wheels[1].motorTorque = 0;
		wheels[2].motorTorque = 0;
		wheels[3].motorTorque = 0;
		wheels[0].brakeTorque = 300;
		wheels[1].brakeTorque = 300;
		wheels[2].brakeTorque = 300;
		wheels[3].brakeTorque = 300;
	}
}
