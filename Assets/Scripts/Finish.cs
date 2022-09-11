using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Transform FinishPoint;
    public Text textMain;
    public GameObject btnRestart;

    void OnTriggerEnter(Collider other)
    {
        if (Data.DisableInput) return;

        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = FinishPoint.position;
            var rb = other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            textMain.text = "Victory!";
            btnRestart.gameObject.SetActive(true);
            Data.DisableInput = true;
        }
    }
}
