using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnJumpPerformed;
    public event EventHandler OnSprintPerformed;
    public event EventHandler OnSprintCanceled;

    public static GameInput Instance;

    private PlayerControls playerControls;

    private void Awake()
    {
        Instance = this;

        playerControls = new PlayerControls();

        playerControls.Player.Jump.performed += Jump_performed;
        playerControls.Player.Sprint.performed += Sprint_performed;
        playerControls.Player.Sprint.canceled += Sprint_canceled;
    }

    private void Sprint_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSprintCanceled?.Invoke(this, EventArgs.Empty);
    }

    private void Sprint_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSprintPerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpPerformed?.Invoke(this, EventArgs.Empty);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

}
