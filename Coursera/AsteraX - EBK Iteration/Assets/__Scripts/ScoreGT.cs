using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGT : MonoBehaviour {

    public static int gameScore = 0;
    private static Text _scoreText;

    void Start()
    {
        _scoreText = GetComponent<Text>();
        Display();
    }

    // Update is called once per frame
    public static void Display() {
        _scoreText.text = gameScore.ToString();
	}

}
