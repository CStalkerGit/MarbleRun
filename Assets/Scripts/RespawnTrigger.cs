using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RespawnTrigger : MonoBehaviour
{
    Transform lastCheckpoint;

    void FixedUpdate()
    {
        if (transform.position.y < -5.0f && lastCheckpoint)
        {
            transform.position = lastCheckpoint.position;
            var rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Engine.UpdateRespawnPoint(transform.position, ref lastCheckpoint);
    }
}
