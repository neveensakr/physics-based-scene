using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    private Rigidbody rb;

    public float Force = 1f;
    public float TargetHeight = 1f;
    public float DampenForce = 4f;
    public float MaxDampen = 4f;
    public float MaxHeight = 1f;

    public float onGroundThreshold = 1f;
    public bool onGround = false;

    [SerializeField]
    private float _groundDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void CalcDistance()
    {
        RaycastHit hit;
        var range = 1000f;
        var hitSomething = Physics.Raycast(transform.position, Vector3.down, out hit, range);
        Debug.DrawRay(transform.position, Vector3.down * range, Color.yellow);

        if (hitSomething)
        {
            _groundDistance = hit.distance;
        }
        else
        {
            _groundDistance = range;
        }
    }

    private void FixedUpdate()
    {
        CalcDistance();
        onGround = _groundDistance <= onGroundThreshold;

        if (onGround)
        {
            var distance = TargetHeight - _groundDistance;
            var forceToApply = distance * Force - Mathf.Clamp(rb.velocity.y * DampenForce, -MaxDampen, MaxDampen);
            rb.AddForce(new Vector3(0, forceToApply, 0));
        }

    }
}
