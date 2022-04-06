using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public static Damage Instance;

    [SerializeField]
    private float _damageForce;

    private Rigidbody rb;
    private float distance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void DamagePlayer(float dist)
    {
        distance = dist;
        rb.AddForce(new Vector3(distance * _damageForce, 0, 0));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, new Vector3(distance * _damageForce, 0, 0));
    }
}
