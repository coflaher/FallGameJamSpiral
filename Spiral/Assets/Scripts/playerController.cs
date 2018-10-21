using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


    [SerializeField] Rigidbody rb;
    public bool enableMove = true;
    float speed = 30f;
    public float maxSpeed = 100f;
    public AudioSource moveSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.GetComponent<Rigidbody>().drag = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
	void FixedUpdate()
	{
        if (enableMove)
        {
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
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                // moveSound.Play();
                moveSound.volume = 1.0f;
            }
            else
            {
                // moveSound.Stop();
                moveSound.volume = 0.0f;
            }
            
        }
        
    }

}
