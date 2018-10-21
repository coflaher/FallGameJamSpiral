using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


	[SerializeField] Rigidbody rb;
	float speed = 10f;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get float for horizontal input
        float moveVertical = Input.GetAxis("Vertical");	// Get float for vertical input

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f); // Combine inputs for vector value

        rb.AddForce(movement * speed);	// Applies force based on vector from inputs.
    }

}
