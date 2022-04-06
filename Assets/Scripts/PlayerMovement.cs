using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed = 1.0f;
    public float maxSpeed = 20f;
    public float DampenForce = 4f;
    public float MaxDampen = 4f;

    public float jumpHeight = 1f;
    private float _jumpForce = 0.0f;
    private Float FloatScript;

    private Intention _intention;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FloatScript = FindObjectOfType<Float>();
        _intention = GetComponent<Intention>();
    }

    private void Update()
    {
        if (FloatScript.onGround)
            VerticalMovement();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        var dampener = Mathf.Clamp(rb.velocity.x * DampenForce, -MaxDampen, MaxDampen);
        
        rb.AddForce(new Vector3((_intention.GetAxis("Horizontal") * moveSpeed) - dampener, 0.0f, 0.0f));
    }

    private void VerticalMovement()
    {
        _jumpForce = _intention.Jump() ? jumpHeight : rb.velocity.y;

        rb.velocity = new Vector3(rb.velocity.x, _jumpForce, rb.velocity.z);
    }

}
