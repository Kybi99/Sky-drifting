using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    private static int numberOfObstacles = 0;
    private static int numberOfCollectibles = 0;

    public TMP_Text obstaclesNum;
    public TMP_Text collectiblesNum;
    public TMP_Text maxSpeed;
    public TMP_Text sens;

    public GameObject settingsCanvas;
    public GameObject playModeCanvas;
    public GameObject xImage;

    public GameObject[] obstacles;
    public GameObject[] collectibles;



    private void Update()
    {
        obstaclesNum.text = numberOfObstacles.ToString();
        collectiblesNum.text = numberOfCollectibles.ToString();
        maxSpeed.text = CarController.maxSpeed.ToString();
        if (settingsCanvas.activeSelf)
        {
            Time.timeScale = 0;
        }
        else if(playModeCanvas.activeSelf)
        {
            Time.timeScale = 1;
        }

    }
    public static void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioListener.volume = 1;

        DetectSwipe.firstTimeTapped = true;
    }

    public void SettingsMenuShow()
    {
        if (settingsCanvas.activeSelf)
        {
            playModeCanvas.SetActive(true);
            settingsCanvas.SetActive(false);
            Time.timeScale = 1;

        }
        else if (playModeCanvas.activeSelf)
        {
            playModeCanvas.SetActive(false);
            settingsCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void MuteUnmuteSound()
    {
        Debug.Log(AudioListener.volume);
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            xImage.SetActive(true);
        }
        else if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            xImage.SetActive(false);
        }

    }

    public void IncrementObstacles()
    {
        numberOfObstacles++;
        for(int i = 0; i < numberOfObstacles; i++)
        {
            obstacles[i].SetActive(true);
        }
        for (int i = numberOfObstacles; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
    }

    public void DecrementObstacles()
    {
        numberOfObstacles--;
        for (int i = 0; i < numberOfObstacles; i++)
        {
            obstacles[i].SetActive(true);
        }
        for (int i = numberOfObstacles; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
    }

    public void IncrementCollectibles()
    {
        numberOfCollectibles++;
        for (int i = 0; i < numberOfCollectibles; i++)
        {
            collectibles[i].SetActive(true);
        }
        for (int i = numberOfCollectibles; i < collectibles.Length; i++)
        {
            collectibles[i].SetActive(false);
        }
    }
    public void DecrementCollectibles()
    {
        numberOfCollectibles--;
        for (int i = 0; i < numberOfCollectibles; i++)
        {
            collectibles[i].SetActive(true);
        }
        for (int i = numberOfCollectibles; i < collectibles.Length; i++)
        {
            collectibles[i].SetActive(false);
        }
    }


    public void IncremenetSpeed()
    {
        CarController.maxSpeed++;
    }
    public void DecrementSpeed()
    {
        CarController.maxSpeed--;
    }

    public void IncrementStiffnes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        sens.text = "More stiffness";
    }
    public void DecrementStiffness()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        sens.text = "Less stiffness";

    }


}
