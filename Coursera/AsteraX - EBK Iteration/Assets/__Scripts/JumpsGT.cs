using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpsGT : MonoBehaviour {

    [Header("Starting jumps amount")]
    [SerializeField]
    public int startingJumps = 3;

    public static int jumpsLeft;
    private Text _jumpText;

    void Start()
    {
        _jumpText = GetComponent<Text>();
        jumpsLeft = startingJumps;
    }

    // Update is called once per frame
    void Update()
    {
        _jumpText.text = jumpsLeft.ToString() + " Jumps";
    }

}
