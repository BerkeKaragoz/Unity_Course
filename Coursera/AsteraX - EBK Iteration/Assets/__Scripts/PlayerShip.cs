#define DEBUG_PlayerShip_RespawnNotifications

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    // This is a somewhat protected private singleton for PlayerShip
    static private PlayerShip   _S;
    static public PlayerShip    S
    {
        get
        {
            return _S;
        }
        private set
        {
            if (_S != null)
            {
                Debug.LogWarning("Second attempt to set PlayerShip singleton _S.");
            }
            _S = value;
        }
    }

    [Header("Set in Inspector")]
    public float        shipSpeed = 10f;
    public GameObject   bulletPrefab;
    public int          secondsToWaitBeforeJump = 2;

    private bool           _collisionFlag = false; //To avoid removing double jumps
    public SafezoneChecker safezoneChecker;

    Rigidbody              rigid;


    void Awake()
    {
        S = this;

        // NOTE: We don't need to check whether or not rigid is null because of [RequireComponent()] above
        rigid = GetComponent<Rigidbody>();
        safezoneChecker = GetComponent<SafezoneChecker>();
    }


    void Update()
    {
        // Using Horizontal and Vertical axes to set velocity
        float aX = CrossPlatformInputManager.GetAxis("Horizontal");
        float aY = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 vel = new Vector3(aX, aY);
        if (vel.magnitude > 1)
        {
            // Avoid speed multiplying by 1.414 when moving at a diagonal
            vel.Normalize();
        }

        rigid.velocity = vel * shipSpeed;

        // Mouse input for firing
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Fire();
        }

        _collisionFlag = false;
    }


    void Fire()
    {
        // Get direction to the mouse
        Vector3 mPos = Input.mousePosition;
        mPos.z = -Camera.main.transform.position.z;
        Vector3 mPos3D = Camera.main.ScreenToWorldPoint(mPos);

        // Instantiate the Bullet and set its direction
        GameObject go = Instantiate<GameObject>(bulletPrefab);
        go.transform.position = transform.position;
        go.transform.LookAt(mPos3D);
    }

    static public float MAX_SPEED
    {
        get
        {
            return S.shipSpeed;
        }
    }
    
	static public Vector3 POSITION
    {
        get
        {
            return S.transform.position;
        }
    }

    public void OnCollisionEnter()
    {
            if (_collisionFlag)
            {
                return;
            }

        Jump();
            _collisionFlag = true;

#if DEBUG_PlayerShip_RespawnNotifications
            Debug.Log("Player Ship collided.");
#endif  
        
    }

    //Makes the ship disappear, decreases the jump amount and starts coroutine
    void Jump()
    {
        JumpsGT.jumpsLeft--;
        this.transform.SetPositionAndRotation(new Vector3(50f, 0f, 0f), this.transform.rotation);
        StartCoroutine(WaitAndJump());
    }

    //Waits for X seconds.
    IEnumerator WaitAndJump()
    {
        Vector3 jumpPosition;
        jumpPosition.z = 0f;


#if DEBUG_PlayerShip_RespawnNotifications
        Debug.Log("Before wait");
#endif

        yield return new WaitForSeconds(secondsToWaitBeforeJump);

#if DEBUG_PlayerShip_RespawnNotifications
        Debug.Log("After wait");
#endif

        //TODO safezones
        do
        {
            jumpPosition.x = Random.Range(-15, 16);
            jumpPosition.y = Random.Range(-8, 9);

            safezoneChecker.transform.SetPositionAndRotation(jumpPosition, safezoneChecker.transform.rotation);

#if DEBUG_PlayerShip_RespawnNotifications
            //Draws the safezone checkers radius and position
            Debug.DrawLine(jumpPosition, new Vector3(jumpPosition.x, jumpPosition.y- safezoneChecker.safezoneRadius, jumpPosition.z), Color.blue, secondsToWaitBeforeJump);
#endif
        } while (!safezoneChecker.IsSafe());

        this.transform.SetPositionAndRotation(jumpPosition, this.transform.rotation);
    }
}
