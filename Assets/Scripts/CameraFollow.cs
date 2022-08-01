using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        var newPosition = target.transform.position + cameraOffset;
        transform.position = newPosition;
    }
}
