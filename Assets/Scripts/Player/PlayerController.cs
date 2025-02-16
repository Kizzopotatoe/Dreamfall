using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera playerCamera;

    [Header("Speed")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float jumpForce = 15f;

    [Header("Jump")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;

    private CharacterController characterController;
    private GameInput gameInput;
    private Vector3 moveDirection;
    private Vector3 moveVelocity;
    private bool isJumping = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        gameInput = GameInput.Instance;

        gameInput.OnJumpPerformed += GameInput_OnJumpPerformed;
    }

    private void GameInput_OnJumpPerformed(object sender, System.EventArgs e)
    {
        
    }

    private void Update()
    {
        // Move
        PlayerMove();

        // Jump
        PlayerJump();
    }

    private void PlayerMove()
    {
        Vector2 movement = GameInput.Instance.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);

        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 cameraRight = playerCamera.transform.right;
        cameraRight.y = 0f;

        moveDirection = cameraForward * move.z + cameraRight * move.x;

        // Apply movement
        characterController.Move(moveDirection * Time.deltaTime * playerSpeed);
    }

    private void PlayerJump()
    {
        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                moveVelocity.y = jumpForce;
                isJumping = true;
            }
        }
        else
        {
            if (isJumping && moveVelocity.y <= 0)
            {
                isJumping = false;
            }
        }

        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundCheckRadius, groundLayer);
    }

}
