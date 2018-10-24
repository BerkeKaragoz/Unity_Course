using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float SpeedMultiplier = 50f;

    private Rigidbody rb;
    private Camera mainCamera;
    private RaycastHit hit;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        Move();

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 aimPoint = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(this.transform.position, aimPoint, Color.red);

            transform.LookAt(aimPoint, Vector3.up);
        }
	}

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, SpeedMultiplier * Time.deltaTime);
            //rb.AddTorque(SpeedMultiplier * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-SpeedMultiplier * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(SpeedMultiplier * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -SpeedMultiplier * Time.deltaTime);
        }
        this.transform.SetPositionAndRotation(this.transform.position, Quaternion.Euler(20,0,0) );
    }
}

