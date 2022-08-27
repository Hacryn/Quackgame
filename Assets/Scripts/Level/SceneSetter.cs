using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetter : MonoBehaviour
{
    [SerializeField] private GameObject spell;

    void Start()
    {
        GameObject.FindGameObjectsWithTag("Player")[0].
        GetComponent<AttackController>().skill1[0] = spell;
    }
}
