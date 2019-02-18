using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moving : MonoBehaviour {

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





    public float Speed()
    {
        return wheels[2].radius * wheels[2].rpm * 60 / 1000 * Mathf.PI;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = COM;  
    }

    void Update () {
        HandBrake();

        wheels[0].ConfigureVehicleSubsteps(2000f, 1000, 300);
        wheels[1].ConfigureVehicleSubsteps(2000f, 1000, 300);
        wheels[2].ConfigureVehicleSubsteps(2000f, 1000, 300);
        wheels[3].ConfigureVehicleSubsteps(2000f, 1000, 300);

        GameObject go = GameObject.Find("GameManager");
        UDPObj udpobj = go.GetComponent<UDPObj>();
        float InputSignalNum = udpobj.inputNumber;
        print("move" + InputSignalNum);

        
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

        /*wheels[0].ConfigureVehicleSubsteps(200f, 30, 10);
        wheels[1].ConfigureVehicleSubsteps(200f, 30, 10);
        wheels[2].ConfigureVehicleSubsteps(200f, 30, 10);
        wheels[3].ConfigureVehicleSubsteps(200f, 30, 10);*/

        Carmovement();

        DecelerationSpeed();

    }

    private void Carmovement()
    {
        currentspeed = wheels[2].radius * wheels[2].rpm * 60 / 1000 * Mathf.PI;
        currentspeed = Mathf.Round(currentspeed);

        if(currentspeed < m_Speed && rb.velocity.magnitude <= m_Magnitude)
        {
            float v = Input.GetAxis("Vertical");

            wheels[1].motorTorque = v * enginePower;
            wheels[3].motorTorque = v * enginePower;
            wheels[0].motorTorque = v * enginePower;
            wheels[2].motorTorque = v * enginePower;
        }

        float h = Input.GetAxis("Horizontal");
        wheels[0].steerAngle = h * steerAngle;
        wheels[2].steerAngle = h * steerAngle;
    }

    private void DecelerationSpeed()
    {
        if(!BrakeAllowed && Input.GetButton("Vertical") == false)
        {
            for(int i = 0; i < wc_decelerationSpeed_Length; i++)
            {
                wheels[i].brakeTorque = m_DecelerationSpeed;
                wheels[i].motorTorque = 0;
            }
        }
    }

    private void HandBrake()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            BrakeAllowed = true;
        }
        else
        {
            BrakeAllowed = false;
        }

        if (BrakeAllowed)
        {
            for(int i = 0; i < wc_Torque_Length; i++)
            {
                wheels[i].brakeTorque = m_Brake;
                wheels[i].motorTorque = 0f;
            }
        }else if (!BrakeAllowed && Input.GetButton("Vertical") == true)
        {
            for(int i = 0; i < wc_Torque_Length; i++)
            {
                wheels[i].brakeTorque = 0;
            }
        }
    }
}
