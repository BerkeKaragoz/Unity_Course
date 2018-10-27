using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody ProjectilePrefab;
    public Transform ExitLocation;

    [SerializeField]
    private float SpeedMultiplier = 2500f;
    [SerializeField]
    int ProjectileSpeed = 500;

    private Rigidbody player;
    private Camera mainCamera;
    private RaycastHit hit;
    private Vector3 aimPoint = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        getAimPoint();
        transform.LookAt(aimPoint, Vector3.up);//Looks at the mouse
        Move();

        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    public void Move()
    {
        player.AddForce(0, 0, Input.GetAxisRaw("Vertical") * SpeedMultiplier * Time.deltaTime);
        player.AddForce(Input.GetAxisRaw("Horizontal") * SpeedMultiplier * Time.deltaTime, 0, 0);
        
        this.transform.SetPositionAndRotation(this.transform.position, new Quaternion(Mathf.PI * Input.GetAxis("Vertical") / 12, this.transform.rotation.y, Mathf.PI * -Input.GetAxis("Horizontal") / 12, this.transform.rotation.w));
        //print(this.transform.rotation);
    }

    public Vector3 getAimPoint()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            aimPoint = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(this.transform.position, aimPoint, Color.blue);
        }
        return aimPoint;
    }

    public void Shoot()
    {
        Rigidbody Projectile = Instantiate(ProjectilePrefab, new Vector3(ExitLocation.position.x, 0, ExitLocation.position.z), ExitLocation.rotation) as Rigidbody;
        Projectile.AddRelativeForce(Vector3.forward * ProjectileSpeed);
    }
}

