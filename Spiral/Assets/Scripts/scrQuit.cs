using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrQuit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Quit").GetComponentInChildren<Text>().text = "Quit";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

public class ExitOnClick : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
}

