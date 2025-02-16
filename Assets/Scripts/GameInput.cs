using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnJumpPerformed;

    public static GameInput Instance;

    private PlayerControls playerControls;

    private void Awake()
    {
        Instance = this;

        playerControls = new PlayerControls();

        playerControls.Player.Jump.started += Jump_performed;
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
