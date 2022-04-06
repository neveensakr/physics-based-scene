using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, Intention
{
    public float GetAxis(string axis)
    {
        return Input.GetAxisRaw(axis);
    }

    public bool Jump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

}
