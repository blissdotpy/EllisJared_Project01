using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    
    Vector3 moveDirection;
    Transform cameraObject;

    Rigidbody playerRigidbody;

    public bool isSprinting;
    public bool isWalking;
    
    [Header("Movement Speeds")]
    public float walkingSpeed = 1.5f;
    public float sprintingSpeed = 7;

    public float runningSpeed = 5;
    public float rotationSpeed = 15;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right * inputManager.horizontalInput;
        moveDirection.y = 0;
        moveDirection.Normalize();

        if (isSprinting)
        {
            moveDirection *= sprintingSpeed;
        }
        else if (isWalking)
        {
            moveDirection *= walkingSpeed;
        }
        else
        {
            moveDirection *= runningSpeed;
        }

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection += cameraObject.right * inputManager.horizontalInput;
        targetDirection.y = 0;
        targetDirection.Normalize();

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
}
