using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody PlayerBody;
    float jumpSpeed = 5f;
    float speed = 10f;
    Vector2 moveInput;
    Vector3 movement;
    private PlayerInputActions InputActions;
    private void Awake()
    {
        PlayerBody = GetComponent<Rigidbody>();
        InputActions = new PlayerInputActions();
        InputActions.Player.Enable();
    }
    private void FixedUpdate()
    {
        moveInput = InputActions.Player.Move.ReadValue<Vector2>();
        movement.x = moveInput.x;
        movement.z = moveInput.y;
        PlayerBody.AddForce(movement * speed, ForceMode.Force);
    }
    void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PlayerBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }
}
