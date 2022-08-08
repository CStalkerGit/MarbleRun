using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool Moving;
    public bool Rotating;

    bool movingLeft;
    float maxZ = 1;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = transform.position.z > 0;
        maxZ = Mathf.Abs(transform.position.z);
    }

    void Update()
    {
        if (Rotating) transform.Rotate(0, 50 * Time.deltaTime, 0);
        if (Moving)
        {
            var pos = transform.position;
            var length = 5 * Time.deltaTime;
            if (movingLeft)
            {
                pos.z -= length;
                if (pos.z < -maxZ) movingLeft = false;
            } 
            else
            {
                pos.z += length;
                if (pos.z > maxZ) movingLeft = true;
            }
            transform.position = pos;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
