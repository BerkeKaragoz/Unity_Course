using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float SpeedMultiplier = 2500f;
    

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

        LookAtMouse();
        Move();
        
    }

    public void Move()
    {
            rb.AddForce(0, 0, Input.GetAxisRaw("Vertical") * SpeedMultiplier * Time.deltaTime);
            rb.AddForce(Input.GetAxisRaw("Horizontal") * SpeedMultiplier * Time.deltaTime, 0, 0);

        //this.transform.SetPositionAndRotation(this.transform.position, Quaternion.Euler(this.transform.rotation.x + 20f * Input.GetAxis("Vertical"), this.transform.rotation.y, this.transform.rotation.z + 20f * -Input.GetAxis("Horizontal")));

        this.transform.SetPositionAndRotation(this.transform.position, new Quaternion(Mathf.PI * Input.GetAxis("Vertical") / 12, this.transform.rotation.y,  Mathf.PI * -Input.GetAxis("Horizontal") / 12, this.transform.rotation.w));

        print(this.transform.rotation);

    }

    public void LookAtMouse()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 aimPoint = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(this.transform.position, aimPoint, Color.blue);

            transform.LookAt(aimPoint, Vector3.up);
            //transform.LookAt()
        }
    }
}

