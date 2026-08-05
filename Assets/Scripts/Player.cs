using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Debug")]
    public bool enableDebug = false;

    [Header("Prefabs")]
    [SerializeField] private GameObject projectilePrefab;

    [Header("References")]
    [SerializeField] private Transform cameraPivot;

    private CharacterController controller;

    [Header("Input Variables")]
    // Axis names
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private string jumpButton = "Jump";
    private string shootButton = "Fire1";
    private string mouseHorizontalAxis = "Mouse X";
    private string mouseVerticalAxis = "Mouse Y";

    // Axis values
    private float horizontalInput;
    private float verticalInput;
    private bool jumpInput;
    private bool shootInput;
    private float mouseHorizontalInput;
    private float mouseVerticalInput;

    [Header("Configuration")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpDecay;
    [SerializeField] private float cameraHorizontalSpeed;
    [SerializeField] private float cameraVerticalSpeed;

    [SerializeField] private float maximumCameraAngle;
    [SerializeField] private float minimumCameraAngle;

    [SerializeField] private float projectileLifetime = 2.0f;

    private float xRotation = 0;
    private float yRotation = 0;

    private float jumpModifier;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetReferences();
    }

    void GetReferences()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        UpdateRotation();
        MovePlayer();
        DoJump();
        TurnPlayer();
        TurnCamera();
        ShootProjectile();
    }

    void GetPlayerInput()
    {
        horizontalInput = Input.GetAxis(horizontalAxis);
        verticalInput = Input.GetAxis(verticalAxis);
        jumpInput = Input.GetButtonDown(jumpButton);
        shootInput = Input.GetButtonDown(shootButton);
        mouseHorizontalInput = Input.GetAxis(mouseHorizontalAxis);
        mouseVerticalInput = Input.GetAxis(mouseVerticalAxis);

        if(enableDebug)
        {
            Debug.Log($"Horizontal Input: {horizontalInput}");
            Debug.Log($"Vertical Input: {verticalInput}");
            Debug.Log($"Jump Input: {jumpInput}");
            Debug.Log($"Shoot Input: {shootInput}");
            Debug.Log($"Mouse Horizontal Input: {mouseHorizontalInput}");
            Debug.Log($"Mouse Vertical Input: {mouseVerticalInput}");
        }
    }

    void UpdateRotation()
    {
        xRotation += mouseHorizontalInput * cameraHorizontalSpeed * Time.deltaTime;

        yRotation += mouseVerticalInput * cameraVerticalSpeed * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, minimumCameraAngle, maximumCameraAngle);
    }

    void MovePlayer()
    {
        Vector3 movementVector = Vector3.ClampMagnitude(new Vector3(horizontalInput, 0, verticalInput), 1);
        movementVector = transform.rotation * movementVector;

        // Add movement speed to movement vector
        movementVector *= movementSpeed;

        // Add gravity to movement vector
        movementVector += Physics.gravity;

        // Add jump to movement
        movementVector += Vector3.up * jumpModifier;

        controller.Move(movementVector * Time.deltaTime);

        if(enableDebug)
        {
            Debug.Log($"Movement Vector: {movementVector}");
        }
    }

    void DoJump()
    {
        jumpModifier = jumpModifier - jumpDecay * Time.deltaTime;
        if(jumpModifier < 0)
        {
            jumpModifier = 0;
        }

        if (jumpInput && controller.isGrounded)
        {
            jumpModifier = jumpForce;
        }

        if(enableDebug)
        {
            Debug.Log($"Jump Modifier: {jumpModifier}");
            Debug.Log($"Is Grounded: {controller.isGrounded}");
        }
    }

    void TurnPlayer()
    {
        transform.rotation = Quaternion.AngleAxis(xRotation, Vector3.up);
    }

    void TurnCamera()
    {
        cameraPivot.localRotation = Quaternion.AngleAxis(yRotation, Vector3.right);
    }

    void ShootProjectile()
    {
        if (shootInput)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab);
            projectileInstance.transform.position = cameraPivot.position;
            projectileInstance.transform.rotation = cameraPivot.rotation;

            Destroy(projectileInstance, projectileLifetime);
        }
    }
}
