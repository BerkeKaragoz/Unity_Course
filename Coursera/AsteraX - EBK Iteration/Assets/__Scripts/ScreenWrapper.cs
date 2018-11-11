using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if (this.transform.position.y > Mathf.Abs(9.1f))
        //    this.transform.SetPositionAndRotation(new Vector3(this.transform.position.x, -9, this.transform.position.z), this.transform.rotation);
        //if (this.transform.position.x > Mathf.Abs(9.1f))
        //    this.transform.SetPositionAndRotation(new Vector3(this.transform.position.x, -9, this.transform.position.z), this.transform.rotation);

        this.transform.SetPositionAndRotation(new Vector3(
            ((this.transform.position.x + 16) % 32) - 16 * (this.transform.position.x / Mathf.Abs(this.transform.position.x)), 
            ((this.transform.position.y+9) % 18)-9*(this.transform.position.y/ Mathf.Abs(this.transform.position.y)),
            this.transform.position.z), this.transform.rotation);
    }
}
