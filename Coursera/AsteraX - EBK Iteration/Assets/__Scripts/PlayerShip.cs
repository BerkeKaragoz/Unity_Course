using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerShip : MonoBehaviour
{

    [SerializeField]
    private float SpeedMultiplier = 2500f;

    private Rigidbody player;
    public Rigidbody ProjectilePrefab;
    public Transform ExitLocation;
    public Transform Anchor;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    public void Move()
    {
        player.AddForce(0,  Input.GetAxisRaw("Vertical") * SpeedMultiplier * Time.deltaTime, 0);
        player.AddForce(Input.GetAxisRaw("Horizontal") * SpeedMultiplier * Time.deltaTime, 0, 0);

        Tilt();
    }

    public void Tilt()
    {
        this.transform.SetPositionAndRotation(this.transform.position, new Quaternion(Mathf.PI * Input.GetAxis("Vertical") / 12,  Mathf.PI * -Input.GetAxis("Horizontal") / 12, this.transform.rotation.z, this.transform.rotation.w));

    }

    public void Shoot()
    {
        Rigidbody Projectile = Instantiate(ProjectilePrefab, new Vector3(ExitLocation.position.x, ExitLocation.position.y, 0), ExitLocation.rotation) as Rigidbody;
        Projectile.transform.parent = Anchor.transform;
        Destroy(Projectile.gameObject, 2f);
    }
}
