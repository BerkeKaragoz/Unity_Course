using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour {

    private void Awake()
    {
        this.gameObject.active = false;
    }

    public void Display()
    {
        this.gameObject.active = true;
    }
}
