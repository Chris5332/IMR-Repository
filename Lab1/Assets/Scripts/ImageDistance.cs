using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageDistance : MonoBehaviour
{
    public ObserverBehaviour imageTarget1;
    public ObserverBehaviour imageTarget2;

    private float timer = 0f;

    [HideInInspector] public float distance = -1f;
    void Start()
    {
        if (imageTarget1 == null && imageTarget2 == null)
        {
            Debug.Log("Put the transforms in placeholders.");
            return;
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer>=0.8f)
        {
            bool imageStatus1=false;
            bool imageStatus2=false;

            if (imageTarget1.TargetStatus.Status == Status.TRACKED)
                imageStatus1 = true;

            if (imageTarget2.TargetStatus.Status == Status.TRACKED)
                imageStatus2 = true;

            if (imageStatus1 == true && imageStatus2 == true)
            {
                distance = Vector3.Distance(imageTarget1.transform.position, imageTarget2.transform.position);
                Debug.Log("Distance between ImageTarget1 and ImageTarget2 is: " + distance.ToString() + " meters.");
            }
            else
            {
                distance = 1f;
                if (imageStatus1 == false && imageStatus2 == false)
                    Debug.Log("No ImageTarget visible.");
                else if (imageStatus1 == false)
                    Debug.Log("ImageTarget1 not visible.");
                else
                    Debug.Log("ImageTarget2 not visible.");
            }
            timer = 0f;
        }
    }
}
