using UnityEngine;

public class FPPFController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float sprintMultiplier = 2f;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2f;

    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hide and lock cursor
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D (left/right)
        float moveZ = Input.GetAxis("Vertical");   // W/S (forward/backward)
        float moveY = 0f;

        if (Input.GetKey(KeyCode.Space)) moveY = 1f; // Ascend
        if (Input.GetKey(KeyCode.LeftControl)) moveY = -1f; // Descend

        Vector3 move = transform.right * moveX + transform.forward * moveZ + transform.up * moveY;
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * sprintMultiplier : moveSpeed;

        transform.position += move * currentSpeed * Time.deltaTime;
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limit vertical look

        transform.localRotation = Quaternion.Euler(rotationX, transform.eulerAngles.y + mouseX, 0f);
    }
}
