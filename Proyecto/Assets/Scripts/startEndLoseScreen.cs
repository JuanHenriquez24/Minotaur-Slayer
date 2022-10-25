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
        Cursor.visible = true;
        SceneManager.LoadScene("Lose");
    }
    public void winGame()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Win");
    }
    public void restart()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Start");
    }
    public void closeGame()
    {
        Application.Quit();
    }
}
