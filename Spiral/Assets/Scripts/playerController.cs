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
			counter += Time.deltaTime;
			float step = dir * distance / duration * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
			yield return null;
		}
		yield return new WaitForSeconds(.1f);
		isMove = false;
	}
	
	
}
