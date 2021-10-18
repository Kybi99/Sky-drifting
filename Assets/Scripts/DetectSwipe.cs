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
    private float swipeDistance;

    public static bool firstTimeTapped;
    public static int sensitivity = 4;
    public bool isBreaking;
    public GameManager gameManger;
    [HideInInspector] public float xAxis;
    public float swipeRange;
    public float tapRange;
    [SerializeField] private Transform car;


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

            if(currentPosition.x < startTouchPosition.x)
                swipeDistance =  startTouchPosition.x / currentPosition.x  / sensitivity;
            else if(currentPosition.x > startTouchPosition.x)
                swipeDistance = currentPosition.x / startTouchPosition.x / sensitivity;

            if (swipeDistance > 1)
                swipeDistance = 1;

           /* if(swipeDistance < 1)
                swipeDistance = 1;*/
        }

        if (!stopTouch)
        {
            if (distance.x < -swipeRange)
            {
               // stopTouch = true;
                xAxis = -swipeDistance; 
               // Debug.Log(xAxis);
            }
            else if (distance.x > swipeRange)
            {
                //stopTouch = true;
                xAxis = swipeDistance;
                //Debug.Log(xAxis);
            }
           /* else if (distance.y > swipeRange)
            {
                Debug.Log("up");
                stopTouch = true;
            }*/
            else if (distance.y < -swipeRange)
            {
                Debug.Log("down");
                //stopTouch = true;
                isBreaking = true;
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //Debug.Log("ended");

            //Reset values for calculations
            swipeDistance = 0;
            xAxis = 0;
            distance = Vector3.zero;
            currentPosition = Vector3.zero;
          //  car.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 0));
           //car.rotation = Quaternion.identity;

            //stopTouch = false;
            //isBreaking = false;

            endTouchPosition = Input.GetTouch(0).position;

            distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange)
            {
                Debug.Log(firstTimeTapped);

                if (firstTimeTapped)
                {
                    gameManger.Unpause();
                    firstTimeTapped = false;
                }
            }
        }
    }
}
