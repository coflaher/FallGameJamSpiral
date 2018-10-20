using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


	[SerializeField] Rigidbody rb;
	[SerializeField] Transform target;
	[SerializeField] float distance;
	public bool isMove = false;
	[SerializeField] float duration;
    Vector3 initialPosition;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{	
        if (!isMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                StartCoroutine(move(1, target.position));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine(move(-1, target.position));
            }
        }
	}
	void FixedUpdate()
	{
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (isMove == true)
        {
            StartCoroutine(move(1, initialPosition));
        }
    }

    IEnumerator move(float dir, Vector3 target)
	{
		isMove = true;
		float counter = 0;
		while(counter < duration)
		{
			counter++;
			float step = dir * distance / duration;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
			yield return null;
		}

        for (int i = 0; i < 5; i++)
	    	yield return null;
		isMove = false;
        initialPosition = transform.position;
	}
	
	
}
