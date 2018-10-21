using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuKeyEffect : MonoBehaviour {
    [SerializeField] KeyCode key;
    Vector3 initPos;
	// Use this for initialization
	void Start () {
        initPos = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(key))
        {
            transform.position = initPos + Random.insideUnitSphere * 10;
        }
        else
        {
            transform.position = initPos;
        }
	}
}
