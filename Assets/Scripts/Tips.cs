using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    public Text textMain;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textMain.text = "[Space] to jump";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textMain.text = "";
        }
    }
}
