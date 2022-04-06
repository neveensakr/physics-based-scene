using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _toFollow;
    public Vector3 Offset;

    private void Update()
    {
        gameObject.transform.localPosition = _toFollow.position + Offset;
    }
}
