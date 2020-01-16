using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPopup : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button confirmButton;

    private static readonly string SUCCESS_TEXT = "WINNER!";
    private static readonly string FAIL_TEXT = "LOOSER!";

    public Action OnConfirm;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show(bool success)
    {
        gameObject.SetActive(true);

        DisplayText(success);
    }

    private void DisplayText(bool success)
    {
        text.text = success ? SUCCESS_TEXT : FAIL_TEXT;
    }

    public void Confirm()
    {
        OnConfirm.Invoke();
    }
}
