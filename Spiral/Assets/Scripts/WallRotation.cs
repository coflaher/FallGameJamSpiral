using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotation : MonoBehaviour {

    //[SerializeField] float moveSpeed = .1f;
    //[SerializeField] float yRotation = 30f;
    [SerializeField] float rotationAngle;
    [SerializeField] bool isRotating = false;
    //[SerializeField] float XAngle;
    //[SerializeField] float YAngle;
    //[SerializeField] float ZAngle;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            print(transform.rotation.eulerAngles.y);
            Quaternion newRotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + rotationAngle, 0));
            StartCoroutine(Rotate(newRotation, 1));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Quaternion newRotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y - rotationAngle, 0));
            StartCoroutine(Rotate(newRotation, 1));
        }
    }

    IEnumerator Rotate(Quaternion newRot, float duration)
    {
        if (isRotating)
        {
            yield break;
        }
        isRotating = true;
   
        Quaternion currentRot = transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        isRotating = false;
    }
}
