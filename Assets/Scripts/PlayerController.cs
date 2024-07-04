using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const float MOVESPEED = 5f;
    private const float SPRINTSPEED = 10f;
    private const float CROUCHSPEED = 2.5f;

    private float currentSpeed
    {
        get { return isSprinting ? SPRINTSPEED : isCrouching ? CROUCHSPEED : MOVESPEED; }
    }
    private bool isCrouching
    {
        get { return player.height == 1; }
        set
        {
            player.height = value ? 1 : 2;
            cameraTransform.position = value ? new Vector3(cameraTransform.position.x, 0.5f, cameraTransform.position.z) : new Vector3(cameraTransform.position.x, 1.5f, cameraTransform.position.z);
        }
    }
    private bool isSprinting = false;
    public float lookSensitivity;

    private float verticalLookRotation = 0f;
    private const float MAX_VERTICAL_LOOK_ANGLE = 80f;

    public Transform cameraTransform;

    private Vector2 moveInput;
    private Vector3 moveDirection;

    private CharacterController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Get the player's forward direction and right direction
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Calculate the desired direction based on player input and orientation
        Vector3 desiredDirection = forward * moveDirection.z + right * moveDirection.x;
        desiredDirection.Normalize();

        // Move the player in the desired direction
        player.Move(desiredDirection * currentSpeed * Time.deltaTime);

    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
    }




    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>() * lookSensitivity;
        float horizontalLook = lookInput.x;
        float verticalLook = -lookInput.y; 

        // Rotate player around the y-axis (horizontal look)
        transform.Rotate(Vector3.up, horizontalLook);

        // Adjust the vertical look rotation and clamp it
        verticalLookRotation += verticalLook;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -MAX_VERTICAL_LOOK_ANGLE, MAX_VERTICAL_LOOK_ANGLE);

        // Apply the clamped vertical look rotation to the camera
        cameraTransform.localEulerAngles = new Vector3(verticalLookRotation, cameraTransform.localEulerAngles.y, 0f);
    }


    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isCrouching = true;

        }
        else if (context.canceled)
        {
            isCrouching = false;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSprinting = true;
        }
        else if (context.canceled)
        {
            isSprinting = false;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump");
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Pause");
        }
    }


    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Interact");
        }
    }


}
