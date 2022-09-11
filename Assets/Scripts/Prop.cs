using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    void FixedUpdate()
    {
        if (transform.position.y < -10.0f) Destroy(gameObject);
    }
}
