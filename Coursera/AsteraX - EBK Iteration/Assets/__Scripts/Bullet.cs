using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    int ProjectileSpeed = 100;

    private Rigidbody BulletRB;

    // Use this for initialization
    void Start () {
        BulletRB = GetComponent<Rigidbody>();

        BulletRB.AddRelativeForce(Vector3.up * ProjectileSpeed, ForceMode.VelocityChange);
    }
	
	// Update is called once per frame
	void Update () {
    }
}
