using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : PickUpItem
{

    [SerializeField] private string nextLevel;

    public override bool OnPickUp(GameObject player)
    {
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        return false;
    }
}
