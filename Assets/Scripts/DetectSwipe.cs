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
        }

        if (!stopTouch)
        {
            if (distance.x < -swipeRange)
            {
                xAxis = -swipeDistance; 
            }
            else if (distance.x > swipeRange)
            {
                xAxis = swipeDistance;
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        { 
            //Reset values for calculations
            swipeDistance = 0;
            xAxis = 0;
            distance = Vector3.zero;
            currentPosition = Vector3.zero;

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
