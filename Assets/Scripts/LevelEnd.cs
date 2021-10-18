using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
	public GameObject endLevelCanvas;
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			EndLevel();
		}
	}

	private void EndLevel()
    {
		endLevelCanvas.SetActive(true);
		Time.timeScale = 0;
	}
}
