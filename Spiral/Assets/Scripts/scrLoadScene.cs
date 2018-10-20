using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrLoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Start").GetComponentInChildren<Text>().text = "Start";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene()
    {
        SceneManager.LoadScene("Test");
    }
}

