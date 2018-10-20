using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 4f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, 1, 0);
        rb.AddForce(movement * speed);

        
    }



    // Update is called once per frame
    void Update () {
		
	}
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
     void OnCollisionExit(Collision collision)
    {
      
    }

     void OnCollisionStay(Collision collision)
    {

    }

}
