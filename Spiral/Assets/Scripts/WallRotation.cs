using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotation : MonoBehaviour {
    
    [SerializeField] float rotationAngle;
    bool isRotating = false;


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
            float newRotation = transform.rotation.eulerAngles.y + rotationAngle;
            StartCoroutine(Rotate(newRotation, 1));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            float newRotation = transform.rotation.eulerAngles.y - rotationAngle;
            StartCoroutine(Rotate(newRotation, 1));
        }
    }

    IEnumerator Rotate(float newRot, float duration)
    {
        if (isRotating)
        {
            yield break;
        }
        isRotating = true;
   
        float currentRot = transform.rotation.eulerAngles.y;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, Mathf.Lerp(currentRot, newRot, counter / duration), 0);
            yield return null;
        }
        isRotating = false;
    }
}
