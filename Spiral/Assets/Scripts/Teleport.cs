using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    [SerializeField] GameObject ball;
    [SerializeField] GameObject teleportPoint;
    [SerializeField] bool enable = true;
    public AudioSource teleportSound;
    bool onTrigger = false;

    // Use this for initialization
    void OnTriggerEnter(Collider collision)
    {
        if (ball == collision.gameObject && !onTrigger && ball.GetComponent<Collider>().enabled)
        {
            teleportSound.Play();
            ball.GetComponent<Collider>().enabled = false;
            ball.GetComponent<playerController>().enableMove = false;
            teleportPoint.GetComponent<Teleport>().onTrigger = true;
            StartCoroutine(BallSucc(20));
        }
    }

    void OnTriggerExit(Collider collision)
    {
        onTrigger = false;
    }

    IEnumerator BallSucc(float duration)
    {
        for (int i = 0; i < duration; i++)
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, transform.position, i / duration);
            yield return null;
        }

        ball.transform.position = teleportPoint.transform.position;
        ball.GetComponent<Collider>().enabled = true;
        ball.GetComponent<playerController>().enableMove = true;
    }
}
