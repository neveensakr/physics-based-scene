using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour, Intention
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private ParticleSystem _particles;

    private float _distance;
    private bool _hurtingPlayer;

    public float GetAxis(string axis)
    {
        _distance = _target.position.x - transform.position.x;
        bool reached = Mathf.Abs(_distance) < 5f;
        return (axis == "Horizontal" && !reached) ? Mathf.Clamp(_distance, -1, 1) : 0;
    }

    private void Update()
    {
        if (Mathf.Abs(_distance) < 6)
        {
            if (!_hurtingPlayer)
                InvokeRepeating("HurtPlayer", 0, 5f);
        }
        else
        {
            CancelInvoke("HurtPlayer");
            _hurtingPlayer = false;
            _particles.Stop();
        }
    }

    public bool Jump()
    {
        return false;
    }

    private void HurtPlayer()
    {
        _hurtingPlayer = true;
        Damage.Instance.DamagePlayer(_distance);
        _particles.Play();
    }
}
