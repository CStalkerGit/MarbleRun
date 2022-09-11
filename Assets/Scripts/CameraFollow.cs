using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;

    float rAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        var newPosition = target.transform.position + cameraOffset;

        if (Data.DisableInput)
        {
            rAngle += Time.deltaTime * 30;
            newPosition = target.transform.position + Quaternion.Euler(0, rAngle, 0) * cameraOffset;
        }

        transform.position = newPosition;
        transform.LookAt(target);
    }
}
