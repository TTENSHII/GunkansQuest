using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void LoadLevel(int nb)
    {
        switch (nb)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
                break;
        }
    }

    public void LoadGameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    public void LoadEndGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndGameScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
