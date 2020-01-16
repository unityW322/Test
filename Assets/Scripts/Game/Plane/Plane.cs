using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Plane : MonoBehaviour
{
    [SerializeField] private float movespeed;

    [SerializeField] private BallController playerController;

    [SerializeField] private FinishLine end;

    [SerializeField] private List<Pack> packs;

    private bool isExitTriggered;
    private bool isMovementTriggered;

    public Action OnPlaneIsAboutToEnd;

    public Action OnFallDown;
    public Action OnFinish;

    private void Start()
    {
        end.OnFinish += () => OnFinish.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!isExitTriggered && collision.gameObject == playerController.gameObject)
        {
            isExitTriggered = true;

            Debug.LogError("You are dead");
            playerController.FallDown();

            OnFallDown.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (isMovementTriggered)
        {
            transform.position += -Vector3.forward * Time.deltaTime * movespeed;

            float isAboutToLeavePlane = transform.position.z % 45;
            if (OnPlaneIsAboutToEnd != null && isAboutToLeavePlane <= -30)
            {
                OnPlaneIsAboutToEnd.Invoke();
                OnPlaneIsAboutToEnd = null;
            }
            else if (isAboutToLeavePlane <= -50f)
                gameObject.SetActive(false);
        }
    }

    public void StartMovement(Vector3 prev)
    {
        isMovementTriggered = true;

        if (prev == Vector3.zero)
            return;

        Vector3 targetPosition = prev;
        targetPosition.z += 50;

        transform.position = targetPosition;

        PickRandomPackToGenerate();
    }

    private void PickRandomPackToGenerate()
    {
        int randomIndex = UnityEngine.Random.Range(0, packs.Count);

        for (int i = 0; i < packs.Count; i++)
        {
            Pack pack = packs[i];

            bool isChosenPack = i == randomIndex;

            if (isChosenPack)
                pack.GenerateObsticles();

            pack.gameObject.SetActive(isChosenPack);
        }
    }

    public void StartMovement()
    {
        isMovementTriggered = true;

        PickRandomPackToGenerate();
    }
}
