using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void FadeToBlack(float duration)
    {
        StartCoroutine(FadeIn(duration));
    }

    public void FadeFromBlack(float duration)
    {
        StartCoroutine(FadeOut(duration));
    }

    IEnumerator FadeIn(float duration)
    {
        for (int i = 1; i <= duration; i++)
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, i/duration);
            yield return null;
        }
    }

    IEnumerator FadeOut(float duration)
    {
        for (int i = 1; i <= duration; i++)
        {
            GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, (duration - i) / duration);
            yield return null;
        }
    }
}
