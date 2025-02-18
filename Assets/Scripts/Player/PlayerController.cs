using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [Header("Camera")]
    [SerializeField] private Camera playerCamera;

    [Header("Speed")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float jumpForce = 15f;

    [Header("Jump")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;

    private CharacterController characterController;
    private GameInput gameInput;
    private bool isJumping = false;
    private bool isSprinting = false;
    private float moveVelocityY = 0f;
    public bool canMove = true;
    private float initialGravity;

    private void Awake()
    {
        Instance = this;

        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        canMove = true;
        gameInput = GameInput.Instance;
        initialGravity = gravity;

        gameInput.OnJumpPerformed += GameInput_OnJumpPerformed;
        gameInput.OnSprintPerformed += GameInput_OnSprintPerformed;
        gameInput.OnSprintCanceled += GameInput_OnSprintCanceled;
    }

    // EVENTS FOR INPUT
    private void GameInput_OnSprintCanceled(object sender, System.EventArgs e)
    {
        isSprinting = false;
    }

    private void GameInput_OnSprintPerformed(object sender, System.EventArgs e)
    {
        isSprinting = true;
    }

    private void GameInput_OnJumpPerformed(object sender, System.EventArgs e)
    {
        if(IsGrounded() && !isJumping)
        {
            moveVelocityY = jumpForce;
            isJumping = true;
        }
    }

    private void Update()
    {
        if(!canMove)
        {
            StartCoroutine(CanMove());
            return;
        }
        
        else
        {
            // Move
            PlayerMove();

            // Jump
            PlayerJump();
        }
        
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

        Vector3 moveDirection = cameraForward * move.z + cameraRight * move.x;

        // Determine speed based on whether player is spritning or not
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        // Apply movement
        characterController.Move(moveDirection * Time.deltaTime * currentSpeed);
    }

    private void PlayerJump()
    {
        if (IsGrounded())
        {
            if(isJumping && moveVelocityY <= 0f)
            {
                isJumping = false;
            }
        }
        else
        {
            moveVelocityY += gravity * Time.deltaTime;
        }

        Vector3 velocity = new Vector3(0f, moveVelocityY, 0f);
        characterController.Move(velocity * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundCheckRadius, groundLayer);
    }

    IEnumerator CanMove()
    {
        yield return new WaitForSeconds(0.1f);

        canMove = true;
    }

    public void DisableGravity()
    {
        gravity = 0f;
    }

    public float EnableGravity()
    {
        gravity = initialGravity;
        return gravity;
    }
}
