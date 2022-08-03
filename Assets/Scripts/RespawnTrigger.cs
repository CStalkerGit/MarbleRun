using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RespawnTrigger : MonoBehaviour
{
    public Transform RespawnPoint;

    void FixedUpdate()
    {
        if (transform.position.y < -2.0f && RespawnPoint)
        {
            transform.position = RespawnPoint.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
