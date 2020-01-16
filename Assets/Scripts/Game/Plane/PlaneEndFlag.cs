using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PlaneEndFlag : MonoBehaviour
{
    private Renderer renderer;

    public Action<Vector3> OnFlagReached;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        if (renderer.isVisible && OnFlagReached != null)
        {
            OnFlagReached.Invoke(this.transform.position);
            OnFlagReached = null;
        }
    }
}
