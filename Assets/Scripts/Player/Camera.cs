using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform followedTransform;

    [SerializeField]
    private int offsetX;

    [SerializeField]
    private int offsetY;

    void Update()
    {
        this.transform.position = 
        new Vector3(followedTransform.position.x + offsetX, 
        followedTransform.position.y + offsetY, 
        this.transform.position.z);
    }
}
