using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpsGT : MonoBehaviour {

    [Header("Starting jumps amount")]
    [SerializeField]
    public static int startingJumps = 3;

    private static int _jumpsLeft;
    private static Text _jumpText;

    void Start()
    {
        _jumpText = GetComponent<Text>();
        _jumpsLeft = startingJumps;
        Display();
    }

    public static int GetJumpsLeft()
    {
        return _jumpsLeft;
    }

    public static void DecrementJumpsLeft()
    {
        _jumpsLeft--;
    }

    public static void Display()
    {
        _jumpText.text = _jumpsLeft.ToString() + " Jumps";
    }

}
