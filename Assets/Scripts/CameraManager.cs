using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform target;

    void Start()
    {
        target = PlayerMovement.Instance.transform;
    }

    void LateUpdate()
    {
        transform.position = target.position;
    }
}
