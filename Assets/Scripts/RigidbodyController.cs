using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class RigidbodyController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public Text textDebug;

    public bool IsGrounded { get; private set; }

    Vector3 move = Vector3.zero;
    Rigidbody rb;
    SphereCollider sphereCollider;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        // movement
        float x = Input.GetAxisRaw("Vertical");
        float z = -Input.GetAxisRaw("Horizontal");
        move.Set(x, move.y, z);
        move.Normalize();

        // jumping
        if (IsGrounded && Input.GetButton("Jump"))
        {
            IsGrounded = false;
            move.y = Mathf.Sqrt(2 * Physics.gravity.magnitude * jumpHeight);
        }

       // if (textDebug) textDebug.text = rb.velocity.ToString();
    }

    void FixedUpdate()
    {
        rb.AddForce(move * moveSpeed);
        move = Vector3.zero;

        // clamp max speed
        if (rb.velocity.x > moveSpeed) rb.velocity = new Vector3(moveSpeed, rb.velocity.y, rb.velocity.z);

        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, sphereCollider.radius + 0.1f);

        IsGrounded = hit.collider;
        if (textDebug && hit.collider) textDebug.text = hit.collider.name;
    }
}
