using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upright : MonoBehaviour
{
    private Rigidbody rb;
    public float Force = 1f;
    private float _startAngle;
    private Vector3 _startAxis;

    public float DampenForce = 1f;
    public float MaxDampen = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation.ToAngleAxis(out _startAngle, out _startAxis);
    }

    private void FixedUpdate()
    {
        var goalRotation = ShortestRotation(Quaternion.AngleAxis(_startAngle, _startAxis), transform.rotation);
        // Current Angle
        float currentAngle = 0f;
        Vector3 currentAxis = Vector3.zero;
        goalRotation.ToAngleAxis(out currentAngle, out currentAxis);

        float rotRadians = currentAngle * Mathf.Deg2Rad;
        currentAxis.Normalize();

        // Rotate to the Start angle from the current angle.
        rb.AddTorque(rotRadians * currentAxis * Force - (rb.angularVelocity * DampenForce));
    }

    public static Quaternion ShortestRotation(Quaternion a, Quaternion b)
    {
        if (Quaternion.Dot(a, b) < 0)
        {
            return a * Quaternion.Inverse(Multiply(b, -1));
        }
        else
        {
            return a * Quaternion.Inverse(b);
        }
    }

    public static Quaternion Multiply(Quaternion input, float scalar)
    {
        return new Quaternion(input.x * scalar, input.y * scalar, input.z * scalar, input.w * scalar);
    }
}
