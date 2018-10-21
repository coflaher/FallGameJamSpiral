using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


	[SerializeField] Rigidbody rb;
    public bool enableMove = true;
	float speed = 30f;
	public float maxSpeed = 100f;
	
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
        if (enableMove)
        {
            //var horizontalMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            //var verticalMovement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
            //var newPos = rb.position + new Vector3(horizontalMovement, verticalMovement, 0);
            //rb.MovePosition(newPos);

            //////Horizontal movement border
            ////Vector3 pos = transform.position;

            ////pos.x = Mathf.Clamp(pos.x + horizontalMovement, -9, 9);
            ////pos.y = Mathf.Clamp(pos.y, -9, 9);

            //transform.position = pos;
            float moveHorizontal = Input.GetAxis("Horizontal"); // Get float for horizontal input
            float moveVertical = Input.GetAxis("Vertical"); // Get float for vertical input

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f); // Combine inputs for vector value
            if (rb.velocity.magnitude <= maxSpeed)
            {
                rb.AddForce(movement * speed);  // Applies force based on vector from inputs.
            }
            else if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;

            }
        }
    }

}
