using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSwipe : MonoBehaviour
{
    private Vector3 startTouchPosition;
    private Vector3 currentPosition;
    private Vector3 endTouchPosition;
    private Vector3 distance;
    private bool stopTouch = false;
    public float swipeDistance;

    public float xAxis;
    public float swipeRange;
    public float tapRange;

    void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
           // Debug.Log("started");
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            distance = currentPosition - startTouchPosition;
            swipeDistance = currentPosition.x / startTouchPosition.x;
        }

        if (!stopTouch)
        {
            if (distance.x < -swipeRange)
            {
                stopTouch = true;
                xAxis = -swipeDistance; 
               // Debug.Log(xAxis);
            }
            else if (distance.x > swipeRange)
            {
                stopTouch = true;
                xAxis = swipeDistance;
               // Debug.Log(xAxis);
            }
           /* else if (distance.y > swipeRange)
            {
                Debug.Log("up");
                stopTouch = true;
            }
            else if (distance.y < -swipeRange)
            {
                Debug.Log("down");
                stopTouch = true;
            }*/
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //Debug.Log("ended");

            //Reset values for calculations
            swipeDistance = 0;
            xAxis = 0;
            distance = Vector3.zero;
            currentPosition = Vector3.zero;
 
            stopTouch = false;

            //endTouchPosition = Input.GetTouch(0).position;

            //xAxis = 0;
            /*distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange)
            {
                Debug.Log("tap");
            }*/
        }
    }
}
