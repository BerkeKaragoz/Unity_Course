using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

    [SerializeField]
    float PushingPower = 100f;
    [SerializeField]
    float RotationMultiplier = 3f; 
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
     //   DebugLog();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0, PushingPower, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(0, 0, -PushingPower*RotationMultiplier*Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(0, 0, PushingPower*RotationMultiplier*Time.deltaTime);
        }
    }
    private void DebugLog()
    {
        print(Time.deltaTime);
    }
}
