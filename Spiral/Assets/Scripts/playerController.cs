using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


	[SerializeField] Rigidbody rb;
	[SerializeField] Transform target;
	[SerializeField] float distance;
	public static bool isMove = false;
	[SerializeField] float duration;
    [SerializeField] bool collided = false;
    [SerializeField] int collideTest = 0;
    float speed = 10f;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        /*if (!isMove && WallRotation.rotating == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                StartCoroutine(move(1, target.position));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine(move(-1, target.position));
            }
        }*/
	}
	void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        collideTest += 1;
        if (isMove == true)
        {
            collided = true;
        }
    }

    IEnumerator move(float dir, Vector3 target)
	{
		isMove = true;
		float counter = 0;
        Vector3 initialPosition = transform.position;

		while(counter < duration)
        {
            float step = dir * distance / duration;

            if (collided)
            {
                float counter2 = counter;
                Vector3 newPosition = transform.position;
                while (counter > 0 )
                {
                    counter--;
                    transform.position = Vector3.Lerp(initialPosition, newPosition, counter / counter2);
                    yield return null;
                }

                for (int i = 0; i < 5; i++)
                    yield return null;
                isMove = false;
                collided = false;
                yield break;
            }

			counter++;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
			yield return null;
		}

        for (int i = 0; i < 5; i++)
	    	yield return null;
		isMove = false;
	}
	
	
}
