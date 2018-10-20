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
        if (!isRotating)
        {
            Move();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            float newRotation = transform.rotation.eulerAngles.y + rotationAngle;
            StartCoroutine(Rotate(newRotation, 1));
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            float newRotation = transform.rotation.eulerAngles.y - rotationAngle;
            StartCoroutine(Rotate(newRotation, 1));
        }
    }

    IEnumerator Rotate(float newRot, float duration)
    {
        isRotating = true;
   
        float currentRot = transform.rotation.eulerAngles.y;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, Mathf.Lerp(currentRot, newRot, counter / duration), 0); //normalizes angle between -180 and 180
            yield return null;
        }
        
        for (int i = 0; i < 5; i++)
           yield return null;

        isRotating = false;
    }
}
