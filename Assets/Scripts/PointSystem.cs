using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    private float speed;
    public float points;
    public TMP_Text pointText;
    public Transform car;
    public Rigidbody rigidbody;
    public TMP_Text endScreenPoints;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {

        /*Debug.Log(DetectSwipe.driftValue);
        
        if (car.rotation.y > 30 && car.rotation.y < 45 || car.rotation.y < -30 && car.rotation.y > -45)
            points += speed * 2;*/


        //IsItDrifting


        /* Debug.Log(driftAngle);
         if(driftValue >= 0 && driftValue < 1)*/
        speed = rigidbody.velocity.magnitude;
        if(Mathf.FloorToInt(speed) != 0 && Time.timeScale == 1)
            points += speed / 100 ;

        endScreenPoints.text = points.ToString("F0");
        pointText.text = points.ToString("F0");
    }
    
    public void CollectedPoints()
    {
        points += 20;
    }
}
