using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spell;

    void Start()
    {
        player.GetComponent<AttackController>().skill1[0] = spell;
    }
}
