using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float stress = rb.velocity.x > rb.velocity.y ? rb.velocity.x : rb.velocity.y;
        CameraShake.Instance.InduceStress(stress * 0.5f);
    }
}
