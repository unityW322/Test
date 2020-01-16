using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private BallController player;
    [SerializeField] private Plane initialPlane;
    [SerializeField] private NotificationPopup popup;

    [Space(15)]
    [SerializeField] private Settings settings;
    [SerializeField] private SoundManager soundManager;

    private void Start()
    {
        initialPlane.OnFallDown += Lose;
        popup.OnConfirm += LoadMenu;

        soundManager.SetVolume(settings.SoundOn);
    }

    private void Lose()
    {
        popup.Show(success: false);
    }

    private void Win()
    {
        popup.Show(success: true);
    }

    private void LoadMenu()
    {
        GetComponent<SceneLoad>().LoadMenuScene();
    }

    public void StartGame()
    {
        initialPlane.StartMovement();
    }
}
