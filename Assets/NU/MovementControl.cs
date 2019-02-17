using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {
    Rigidbody rb;
    public Vector3 COM = new Vector3(0, 0, 0);
    public WheelCollider[] wc;

    public int wc_Torque_Length;

    public float m_Torque = 2500f;
    public float m_Steer = 25f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = COM;
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < wc_Torque_Length; i++)
        {
            wc[i].motorTorque = Input.GetAxis("Vertical") * m_Torque;
        }

        wc[0].steerAngle = Input.GetAxis("Horizontal") * m_Steer;
        wc[1].steerAngle = Input.GetAxis("Horizontal") * m_Steer;
    }
}
