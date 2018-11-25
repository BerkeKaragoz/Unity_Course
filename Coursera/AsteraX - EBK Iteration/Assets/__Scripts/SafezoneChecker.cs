#define DEBUG_SafezoneChecker

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SafezoneChecker : MonoBehaviour {


    //private GameObject _safezoneCheckerGO;//Has a collider that checks if a zone is empty or not
    public static SphereCollider safezoneChecker;
    public GameObject safezoneCheckerGO;
    public float safezoneRadius = 2.2f;//The radius of the area to check if the jump is safe to be done.

    private bool _isSafe = true;

    // Use this for initialization
    
	void Awake () {
        safezoneChecker = GetComponent<SphereCollider>();
        safezoneChecker.radius = safezoneRadius;
        safezoneCheckerGO = GetComponent<GameObject>();
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
}
