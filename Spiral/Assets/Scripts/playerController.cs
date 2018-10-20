using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


	[SerializeField] Rigidbody rb;
	[SerializeField] Transform target;
	[SerializeField] float distance;
	public bool isMove = false;
	[SerializeField] float duration;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{	
        if (!isMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                StartCoroutine(move(1));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine(move(-1));
            }
        }
	}
	void FixedUpdate()
	{
	}
	
	IEnumerator move(float dir)
	{
		isMove = true;
		float counter = 0;
		while(counter < duration)
		{
			counter++;
			float step = dir * distance / duration;
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), step);
			yield return null;
		}

        for (int i = 0; i < 5; i++)
	    	yield return null;
		isMove = false;
	}
	
	
}
