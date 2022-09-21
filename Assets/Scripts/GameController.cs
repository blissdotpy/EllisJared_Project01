using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour, GameControls.IGameWideInputsActions
{
    GameControls gameControls;

    private void OnEnable()
    {
        gameControls ??= new GameControls();
        gameControls.Enable();
    }

    private void OnDisable()
    {
        gameControls.Disable();
    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
