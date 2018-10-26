using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public Rigidbody ProjectilePrefab;
    public Transform ExitLocation;

    [SerializeField]
    int ProjectileSpeed = 500;

    public ProjectileShooter(Rigidbody ProjectilePrefab, Transform ExitLocation)
    {
        this.ProjectilePrefab = ProjectilePrefab;
        this.ExitLocation = ExitLocation;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Shoot()
    {
        Rigidbody Projectile = Instantiate(ProjectilePrefab, ExitLocation.position, ExitLocation.rotation) as Rigidbody;
        Projectile.AddForce(ExitLocation.forward * ProjectileSpeed);
    }
}
