using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void ToOptions()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void ToCredits()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ToTitle()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Level2()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void Level3()
    {
        SceneManager.LoadSceneAsync(5);
    }


    public void Exit()
    {
        Application.Quit();
    }

   
}
