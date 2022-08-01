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

        var colliders = Physics.OverlapSphere(transform.position - new Vector3(0, 0.1f, 0), sphereCollider.radius);

        string names = "";
        foreach (var e in colliders)
            names += " " + e.name;

        IsGrounded = colliders.Length > 1;
        if (textDebug) textDebug.text = names;
    }
}
