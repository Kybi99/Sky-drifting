using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class UI : MonoBehaviour
{
    private static int numberOfObstacles;
    private static int numberOfCollectibles;
    private string modeString;

    public CameraFollow cameraFollow;
    public GameObject inputTranslation;
    public GameObject inputX;
    public GameObject inputY;
    public GameObject inputZ;
    public GameObject inputRotation;
    public CinemachineVirtualCamera vCam;

    public TMP_Text obstaclesNum;
    public TMP_Text collectiblesNum;
    public TMP_Text maxSpeed;
    public TMP_Text sens;
    public TMP_Text mode;

    public GameObject settingsCanvas;
    public GameObject playModeCanvas;
    public GameObject xImage;

    public GameObject[] obstacles;
    public GameObject[] collectibles;

    private void Start()
    {
        numberOfObstacles = Convert.ToInt32(obstaclesNum.text);
        numberOfCollectibles = Convert.ToInt32(collectiblesNum.text) / 28;
        modeString = mode.text;
    }

    private void Update()
    {
        obstaclesNum.text = numberOfObstacles.ToString();
        collectiblesNum.text = (numberOfCollectibles * 28).ToString();
        maxSpeed.text = (CarController.maxSpeed * 5).ToString() + "Km/h";

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

        if (numberOfObstacles > obstacles.Length)
            numberOfObstacles = obstacles.Length;

        for (int i = 0; i < numberOfObstacles; i++)
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

        if (numberOfObstacles < 0)
            numberOfObstacles = 0;

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

        if (numberOfCollectibles > collectibles.Length)
            numberOfCollectibles = collectibles.Length;

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

        if (numberOfObstacles < 0)
            numberOfObstacles = 0;

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
        if (CarController.maxSpeed > 15)
            CarController.maxSpeed = 15;
    }
    public void DecrementSpeed()
    {
        CarController.maxSpeed--;
        if (CarController.maxSpeed < 13)
            CarController.maxSpeed = 13;
    }

    public void IncrementStiffnes()
    {
        if(modeString == "Easy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            sens.text = "Medium";
        }
        else if (modeString == "Medium")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            sens.text = "Hard";
        }
    }
    public void DecrementStiffness()
    {
        if (modeString == "Medium")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            sens.text = "Easy";
        }
        else if (modeString == "Hard")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            sens.text = "Medium";
        }
    }

    public void SetCameraOffset()
    {
        string x;
        string y;
        string z;
        if(inputTranslation.GetComponent<TMP_InputField>().text != "")
            cameraFollow.translateSpeed = Convert.ToInt32(inputTranslation.GetComponent<TMP_InputField>().text);
        if (inputX.GetComponent<TMP_InputField>().text != "" && inputZ.GetComponent<TMP_InputField>().text != "" && inputY.GetComponent<TMP_InputField>().text != "")
        {
            x = inputX.GetComponent<TMP_InputField>().text;
            y = inputY.GetComponent<TMP_InputField>().text;
            z = inputZ.GetComponent<TMP_InputField>().text;

            cameraFollow.offset = new Vector3(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(z));
        }
        if (inputRotation.GetComponent<TMP_InputField>().text != "")
            cameraFollow.rotationSpeed = Convert.ToInt32(inputRotation.GetComponent<TMP_InputField>().text);
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            var transposer = vCam.GetCinemachineComponent<CinemachineTransposer>();
            transposer.m_FollowOffset = cameraFollow.offset;
        }

    }
       

}
