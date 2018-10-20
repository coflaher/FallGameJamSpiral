using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField] GameObject follow;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - follow.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        transform.position = follow.transform.position + offset;
    }
}
