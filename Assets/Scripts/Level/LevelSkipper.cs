using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSkipper : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.F1)) {
            SceneManager.LoadScene("0A", LoadSceneMode.Single);
        }

        if (Input.GetKey(KeyCode.F2)) {
            SceneManager.LoadScene("0B", LoadSceneMode.Single);
        }

        if (Input.GetKey(KeyCode.F3)) {
            SceneManager.LoadScene("1A", LoadSceneMode.Single);
        }

        if (Input.GetKey(KeyCode.F4)) {
            SceneManager.LoadScene("1B", LoadSceneMode.Single);
        }
    }
}
