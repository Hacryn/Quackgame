using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform followedTransform;

    void Update()
    {
        this.transform.position = new Vector3(followedTransform.position.x, followedTransform.position.y, this.transform.position.z);
    }
}
