using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGT : MonoBehaviour {

    public static int gameScore = 0;
    private Text _scoreText;

    void Start()
    {
        _scoreText = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update () {
        _scoreText.text = gameScore.ToString();
	}

}
