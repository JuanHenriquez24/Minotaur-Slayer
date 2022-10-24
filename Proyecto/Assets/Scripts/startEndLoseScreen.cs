using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startEndLoseScreen : MonoBehaviour
{
    public void startPlaying()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void loseGame()
    {
        SceneManager.LoadScene("Lose");
    }
    public void winGame()
    {
        SceneManager.LoadScene("Win");
    }
    public void restart()
    {
        SceneManager.LoadScene("Start");
    }
    public void closeGame()
    {
        Application.Quit();
    }
}
