using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public Transform RespawnPoint;

    void FixedUpdate()
    {
        if (transform.position.y < 2.0f)
        {
            transform.position = RespawnPoint.position;
        }
    }
}
