using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinState : MonoBehaviour {
   [SerializeField] GameObject ball;
    [SerializeField] GameObject fade;
    [SerializeField] GameObject sceneChange;

    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    bool trigger = false;
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update () {
		
	}
    void OnTriggerEnter(Collider collision)
    {
        if (ball == collision.gameObject && !trigger)
        {
            trigger = true;
            ball.GetComponent<playerController>().enableMove = false;
            StartCoroutine(BallSucc(60));

            if (fade != null)
                fade.GetComponent<Fade>().FadeToBlack(60);

            if (text1 != null)
                StartCoroutine(FadeOutText(text1.GetComponent<UnityEngine.UI.Text>(), 60));

            if (text2 != null)
                StartCoroutine(FadeOutText(text2.GetComponent<UnityEngine.UI.Text>(), 60));

            StartCoroutine(DelayLoadScene(60));
        }
    }

    IEnumerator BallSucc(float duration)
    {
        for (int i = 0; i < duration; i++)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, transform.position, i/duration);
            yield return null;
        }
    }

    IEnumerator DelayLoadScene(int duration)
    {
        for (int i = 0; i < duration; i++)
            yield return null;

        sceneChange.GetComponent<SceneLoader>().LoadNextScene();
    }

    IEnumerator FadeOutText(UnityEngine.UI.Text text, float duration)
    {
        for (int i = 1; i <= duration; i++)
        {
            text.color = new Color((duration - i) / duration, (duration - i) / duration, (duration - i) / duration, 1);
            yield return null;
        }
    }

    void OnCollisionExit(Collision collision)
    {
      
    }

     void OnCollisionStay(Collision collision)
    {

    }


}
