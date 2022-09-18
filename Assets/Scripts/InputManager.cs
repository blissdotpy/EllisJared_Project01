using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;

    public Vector2 movementInput;
    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool shift_Input;
    public bool ctrl_Input;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            
            playerControls.PlayerActions.Shift.performed += i => shift_Input = true;
            playerControls.PlayerActions.Shift.canceled += i => shift_Input = false;
            
            playerControls.PlayerActions.Ctrl.performed += i => ctrl_Input = true;
            playerControls.PlayerActions.Ctrl.canceled += i => ctrl_Input = false;
        }
        
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleWalkingInput();
        // HandleJumpInput
        // HandleActionInput
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount,
                                                playerLocomotion.isSprinting,
                                                playerLocomotion.isWalking);
    }

    private void HandleSprintingInput()
    {
        if (shift_Input && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }

    private void HandleWalkingInput()
    {
        if (ctrl_Input && moveAmount > 0.1f)
        {
            playerLocomotion.isWalking = true;
        }
        else
        {
            playerLocomotion.isWalking = false;
        }
    }
}
