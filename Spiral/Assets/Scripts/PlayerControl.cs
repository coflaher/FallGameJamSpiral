using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour {
    public Transform startpoint;
    public Transform endpoint;
   [SerializeField] GameObject ball;
    
    public float speed = 4f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }


    // Update is called once per frame
    void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
       
        transform.position = Vector3.MoveTowards(startpoint.position ,endpoint.position, speed * Time.deltaTime);
        ball.GetComponent<playerController>().isMove = true;
        
    }
     void OnCollisionExit(Collision collision)
    {
      
    }

     void OnCollisionStay(Collision collision)
    {

    }


}
