using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    
    //cached references

    private void Start()
    {
        //gameStatus = FindObjectOfType<GameSession>();
    }

    public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex; ;
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        //gameStatus.ResetGame();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //declared and defined an integer value of the current build index of the current scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitScene()
    {
        Application.Quit();
    }

}