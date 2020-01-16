using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private Rigidbody sphereBody;

    [Range(1, 30)]
    [SerializeField] private float zOffset;

    [SerializeField] private UnityEvent OnStart;

    private bool isFallingDown;
    private bool isStartInitialized;
    
    private void OnMouseDown()
    {
        if (!isStartInitialized)
        {
            isStartInitialized = true;
            OnStart.Invoke();
        }
    }

    private void OnMouseDrag()
    {
        if (isFallingDown)
            return;

        Vector3 mousePosition = TranslateIntoWorldSpacePos();
        mousePosition.y = 0.5f;

        transform.position = mousePosition;
    }

    private Vector3 TranslateIntoWorldSpacePos()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zOffset;

        return mainCamera.ScreenToWorldPoint(mousePosition);
    }

    public void FallDown()
    {
        isFallingDown = true;
    }
}
