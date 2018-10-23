using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Use this for initialization
    void Start() {
        print("Buradayim konsol!");
        showMainmenu("Berke");
    }

    void showMainmenu(string name)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hi "+ name + "!\nITerminal Since 1968.\n\nChoose what to hack into.\nPress 1 for your own terminal.\nPress 2 for NASA.\nPress 3 for Black Rainbow.");
    }


	// Update is called once per frame
	void Update () {
		
	}
}
