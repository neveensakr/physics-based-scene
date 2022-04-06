using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Intention
{
    public float GetAxis(string axis);

    public bool Jump();
}