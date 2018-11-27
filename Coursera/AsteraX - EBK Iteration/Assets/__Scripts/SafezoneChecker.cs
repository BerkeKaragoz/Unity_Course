#define DEBUG_SafezoneChecker

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SafezoneChecker : MonoBehaviour {


    //Has a collider that checks if a zone is empty or not
    public static SphereCollider safezoneChecker;

    //The radius of the area to check if the jump is safe to be done.
    public float safezoneRadius = 2.2f;
    private bool _isSafe = true;
    private static float _safezoneCheckingTime = 0.3f;
    private GameObject _safezoneCheckerGO;
    
	void Awake () {
        safezoneChecker = GetComponent<SphereCollider>();
        safezoneChecker.radius = safezoneRadius;
        _safezoneCheckerGO = this.gameObject;
        _safezoneCheckerGO.layer = 14;
        /*
        safezoneCheckerGO = new GameObject();
        safezoneChecker = safezoneCheckerGO.AddComponent<SphereCollider>();
        safezoneChecker.center = Vector3.zero;
        safezoneChecker.radius = safezoneRadius;
        safezoneChecker.isTrigger = true;
        safezoneCheckerGO.name = "Safezone Checker";
        safezoneCheckerGO.tag = "SafezoneChecker";
        safezoneCheckerGO.layer = 13;
        */
    }

    void OnTriggerEnter(Collider col)
    {

#if DEBUG_SafezoneChecker
        Debug.Log("Safezone collided.");
#endif
        _isSafe = false;
    }

    void OnTriggerExit(Collider other)
    {
#if DEBUG_SafezoneChecker
        Debug.Log("Safezone is SAFE.");
#endif
        _isSafe = true;
    }

    public bool IsSafe(){
        return _isSafe;
    }

    public float GetSafezoneRadius()
    {
        return safezoneChecker.radius;
    }

    public void DecrementSafezoneRadius()
    {
        safezoneChecker.radius -= 0.1f;
    }

    public void SetSafezoneRadiusInitial()
    {
        safezoneChecker.radius = safezoneRadius;
    }

    public static float getSafezoneCheckingTime()
    {
        return _safezoneCheckingTime;
    }

   

    public void setColliderActive()
    {
        //Sets the collider enabled.
        _safezoneCheckerGO.layer = 13;
        //Layer 13 = SafezoneCheckerEnabled (Checks collusions with asteroids)
    }

    public void setColliderInactive()
    {
        //Sets the collider disabled.
        _safezoneCheckerGO.layer = 14;
        //Layer 14 = SafezoneCheckerDisabled (Checks none)
    }

    
}
