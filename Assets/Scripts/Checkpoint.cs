using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform RespawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var trigger = other.GetComponent<RespawnTrigger>();
            if (trigger) trigger.RespawnPoint = RespawnPoint;
        }
    }
}
