using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject unPauseButton;

    public void PauseGame()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
        pauseButton.SetActive(false);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
