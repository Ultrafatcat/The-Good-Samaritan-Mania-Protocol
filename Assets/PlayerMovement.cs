using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 1000f;
    public float rotationSpeed = 150f;
    public float jumpForce = 500f;

    private PlayerInput playerInput;
    private Vector2 moveInput;

    private float originalMoveSpeed;
    private Coroutine speedBoostCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        originalMoveSpeed = moveSpeed;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Read movement input
        moveInput = playerInput.actions["KeyboardMovement"].ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
        rb.AddRelativeForce(movement * moveSpeed * Time.deltaTime);

        // Handle jumping
        if (playerInput.actions["KeyboardJump"].triggered && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Check if the player is grounded using a raycast
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    public void ApplySpeedBoost(float amount, float duration)
    {
        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine);
        }
        speedBoostCoroutine = StartCoroutine(SpeedBoostCoroutine(amount, duration));
    }

    private IEnumerator SpeedBoostCoroutine(float amount, float duration)
    {
        moveSpeed += amount;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalMoveSpeed;
    }
}