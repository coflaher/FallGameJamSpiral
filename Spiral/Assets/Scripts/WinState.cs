using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinState : MonoBehaviour {
   [SerializeField] GameObject ball;
    [SerializeField] GameObject fade;
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
            fade.GetComponent<Fade>().FadeToBlack(60);
        }
        //transform.position = Vector3.MoveTowards(startpoint.position ,endpoint.position, speed * Time.deltaTime);
        //playerController.isMove = true;
        
    }
     void OnCollisionExit(Collision collision)
    {
      
    }

     void OnCollisionStay(Collision collision)
    {

    }


}
