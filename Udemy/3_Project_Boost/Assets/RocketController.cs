//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{

    [SerializeField]
    float PushingPower = 100f;
    [SerializeField]
    float RotationMultiplier = 3f;

    Rigidbody rb;
    AudioSource audiosource;
    ParticleSystem ps;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
        //   DebugLog();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Safe": print("Safe"); break; 
            case "Resource": print("Resource"); break;
            case "Finish": print("Finish");
                SceneManager.LoadScene(1);
                break;
            default: print("Ded");
                SceneManager.LoadScene(0);
                break;
        }
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(0, 0, -PushingPower * RotationMultiplier * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(0, 0, PushingPower * RotationMultiplier * Time.deltaTime);
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0, PushingPower*Time.deltaTime, 0);
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
                ps.Play();
            }
        }
        else { audiosource.Stop(); ps.Stop(); }
    }

    private void DebugLog()
    {
        print(Time.deltaTime);
    }
}
