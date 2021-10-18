using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas tapToStart;
    public Transform car;
    public AudioSource music;


    void Start()
    {
        Time.timeScale = 0;
 
        DetectSwipe.firstTimeTapped = true;
      
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        music.Play();
    }

    void Update()
    {
        if (car.position.y < -20)
            UI.ResetScene();

        if (Time.timeScale == 1)
            tapToStart.gameObject.SetActive(false);
    }
}
