using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Plane : MonoBehaviour
{
    [SerializeField] private float movespeed;

    [SerializeField] private BallController playerController;

    [SerializeField] private SpriteRenderer StartSprite;
    [SerializeField] private SpriteRenderer EndSprite;

    [SerializeField] private PlaneEndFlag flag;

    private bool isExitTriggered;
    private bool isMovementTriggered;

    public Action OnFallDown;

    private void Start()
    {
        flag.OnFlagReached += StartMovement;
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (!isExitTriggered && collision.gameObject == playerController.gameObject)
    //    {
    //        isExitTriggered = true;

    //        Debug.LogError("You are dead");
    //        playerController.FallDown();

    //        OnFallDown.Invoke();
    //    }
    //}

    private void FixedUpdate()
    {
        if (isMovementTriggered)
            transform.position += -Vector3.forward * Time.deltaTime * movespeed;
    }

    private void StartMovement(Vector3 prev)
    {
        isMovementTriggered = true;

        if (prev == Vector3.zero)
            return;

        Vector3 targetPosition = prev;
        targetPosition.z += prev.z * 10f;

        transform.position = targetPosition;
    }

    public void StartMovement()
    {
        isMovementTriggered = true;
    }
}
