using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotation : MonoBehaviour {
    
    [SerializeField] float rotationAngle;
    bool isRotating = false;
    public static int rotating = 0;
    public AudioSource wallSource;
   
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
        if (Input.GetKey(KeyCode.E))
        {
            float newRotation = transform.rotation.eulerAngles.z + rotationAngle;
            StartCoroutine(Rotate(newRotation, 60));

            if (wallSource != null)
               wallSource.volume = 1.0f;

        }
        else if (Input.GetKey(KeyCode.Q))
        {
            float newRotation = transform.rotation.eulerAngles.z - rotationAngle;
            StartCoroutine(Rotate(newRotation, 60));
            if (wallSource != null)
                wallSource.volume = 1.0f;
        }
        else
        {
            if (wallSource != null)
                wallSource.volume = 0.0f;
        }
    }

    IEnumerator Rotate(float newRot, float duration)
    {
        rotating++;
        isRotating = true;
   
        float currentRot = transform.rotation.eulerAngles.z;

        float counter = 0;
        while (counter < duration)
        {
            counter++;
            transform.rotation = Quaternion.Euler(0,0,Mathf.Lerp(currentRot, newRot, counter / duration)); //normalizes angle between -180 and 180
            yield return null;
        }
        
        for (int i = 0; i < 5; i++)
           yield return null;

        isRotating = false;
        rotating--;
    }
}
