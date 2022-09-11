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
    public Text textMain;

    public bool IsGrounded { get; private set; }

    Vector3 move = Vector3.zero;
    Rigidbody rb;
    SphereCollider sphereCollider;
    float jumpDelay = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (Data.DisableInput) return;

        // movement
        float x = Input.GetAxisRaw("Vertical");
        float z = -Input.GetAxisRaw("Horizontal");
        move.Set(x, 0, z);
        move.Normalize();
        if (IsGrounded) move *= 3;

        // jumping
        jumpDelay -= Time.deltaTime;
        if (IsGrounded && Input.GetButton("Jump") && jumpDelay < 0)
        {
            IsGrounded = false;
            //move.y = jumpHeight;
            jumpDelay = 0.25f;
            rb.AddForce(Vector3.up * jumpHeight);
        }

        //if (textMain) textMain.text = rb.velocity.ToString();
    }

    void FixedUpdate()
    {
        rb.AddForce(move * moveSpeed);
        move = Vector3.zero;

        // clamp max speed
        if (rb.velocity.x > moveSpeed) rb.velocity = new Vector3(moveSpeed, rb.velocity.y, rb.velocity.z);
        if (rb.velocity.x < -moveSpeed) rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, rb.velocity.z);

        IsGrounded = false;
        var colliders = Physics.OverlapSphere(transform.position + Vector3.down * 0.15f, sphereCollider.radius * 0.95f, 1 << 0);
        foreach (var e in colliders)
            if (e.gameObject != gameObject)
            {
                IsGrounded = true;
                break;
            }
    }
}
