using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPointatCursor : MonoBehaviour {

    private Camera mainCamera;
    private RaycastHit hit;
    private Vector3 aimPoint = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {

        mainCamera = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        getAimPoint();
        transform.LookAt(aimPoint, new Vector3(0, 0, -1));
    }

    public Vector3 getAimPoint()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(new Vector3(0,0,-1), Vector3.zero);

        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            aimPoint = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(this.transform.position, aimPoint, Color.blue);

            Debug.DrawLine(mainCamera.transform.position, aimPoint, Color.red);
        }
        return aimPoint;
    }
}
