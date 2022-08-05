using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused = false;
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(isPaused)
            {
                UnPauseGame();
                isPaused = false;
            } else
            {
                PauseGame();
                isPaused = true;
            }
        }
    }

    public void PauseGame()
    {
        foreach(Transform obj in transform)
        {
            obj.gameObject.SetActive(true);
        }

        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        foreach (Transform obj in transform)
        {
            obj.gameObject.SetActive(false);
        }

        Time.timeScale = 1;
    }
}
