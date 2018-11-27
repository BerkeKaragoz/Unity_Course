using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameOverPanel))]
public class ActiveOnlyDuringSomeGameStates : MonoBehaviour {

    public static float gameOverScreenWaitingTime = 5f;
    public GameOverPanel gameOverPanel;

    public bool IsGameEnded()
    {
        if(JumpsGT.GetJumpsLeft() < 0)
        {
            gameOverPanel.Display();
            EndGame();
            return true;
        }
        return false;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreGT.gameScore = 0;
    }

    public void EndGame()
    {
        PlayerShip.S.enabled = false;
        Invoke("Restart", gameOverScreenWaitingTime);
    }

}
