using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    private float points;
    public TMP_Text pointText;
    public Transform carPostion;
    
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points += Mathf.Abs(carPostion.position.x + carPostion.position.z) / 10;
        pointText.text = points.ToString();
    }
    
    public void CollectedPoints()
    {
        points += 100;
    }
}
