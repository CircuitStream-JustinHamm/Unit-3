using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Debug")]
    public bool enableDebug = false;

    [Header("Prefabs")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject rocketPrefab;

    [Header("References")]
    [SerializeField] private Transform cameraPivot;
    [SerializeField] new private Transform camera;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private Transform pickupPivot;
    [SerializeField] private Collider rigidbodyCollider;

    private CharacterController controller;
    new private Rigidbody rigidbody;

    [Header("Input Variables")]
    // Axis names
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private string jumpButton = "Jump";
    private string shootButton = "Fire1";
    private string rocketButton = "Fire2";
    private string mouseHorizontalAxis = "Mouse X";
    private string mouseVerticalAxis = "Mouse Y";
    private string interactButton = "Interact";

    // Axis values
    private float horizontalInput;
    private float verticalInput;
    private bool jumpInput;
    private bool shootInput;
    private bool rocketInput;
    private float mouseHorizontalInput;
    private float mouseVerticalInput;
    private bool interactInput;

    [Header("Configuration")]
    [SerializeField] private bool usingCharacterController = false;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpDecay;
    [SerializeField] private float projectileForce;
    [SerializeField] private float rocketForce;
    [SerializeField] private float cameraHorizontalSpeed;
    [SerializeField] private float cameraVerticalSpeed;

    [SerializeField] private float maximumCameraAngle;
    [SerializeField] private float minimumCameraAngle;

    [SerializeField] private float projectileLifetime = 2.0f;
    [SerializeField] private float rocketLifetime = 2.0f;

    [SerializeField] private float groundedDistance = 0.07f;

    [SerializeField] private float interactionDistance = 1.0f;

    private float xRotation = 0;
    private float yRotation = 0;

    private float jumpModifier;

    private bool wasUsingCharacterController = false;
    private ISelectable selectedObject;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wasUsingCharacterController = !usingCharacterController;
        GetReferences();
    }

    void GetReferences()
    {
        rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleCharacterController();
        GetPlayerInput();
        UpdateRotation();
        MovePlayer();
        DoJump();
        TurnPlayer();
        TurnCamera();
        ShootProjectile();
        ShootRocket();
        Interact();
    }

    void ToggleCharacterController()
    {
        // If we just toggled the character controller...
        if(usingCharacterController != wasUsingCharacterController)
        {
            // And we just turned it on...
            if(usingCharacterController)
            {
                rigidbody.isKinematic = true;
                controller.enabled = true;
                rigidbodyCollider.enabled = false;
            }
            // Or, if we just turned it off...
            else
            {
                rigidbody.isKinematic = false;
                controller.enabled = false;
                rigidbodyCollider.enabled = true;
            }

            wasUsingCharacterController = usingCharacterController;
        }
    }

    void GetPlayerInput()
    {
        horizontalInput = Input.GetAxis(horizontalAxis);
        verticalInput = Input.GetAxis(verticalAxis);
        jumpInput = Input.GetButtonDown(jumpButton);
        shootInput = Input.GetButtonDown(shootButton);
        rocketInput = Input.GetButtonDown(rocketButton);
        mouseHorizontalInput = Input.GetAxis(mouseHorizontalAxis);
        mouseVerticalInput = Input.GetAxis(mouseVerticalAxis);
        interactInput = Input.GetButtonDown(interactButton);

        if(enableDebug)
        {
            Debug.Log($"Horizontal Input: {horizontalInput}");
            Debug.Log($"Vertical Input: {verticalInput}");
            Debug.Log($"Jump Input: {jumpInput}");
            Debug.Log($"Shoot Input: {shootInput}");
            Debug.Log($"Rocket Input: {rocketInput}");
            Debug.Log($"Mouse Horizontal Input: {mouseHorizontalInput}");
            Debug.Log($"Mouse Vertical Input: {mouseVerticalInput}");
            Debug.Log($"Interact Input: {interactInput}");
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

        if (usingCharacterController)
        {
            // Add gravity to movement vector
            movementVector += Physics.gravity;

            // Add jump to movement
            movementVector += Vector3.up * jumpModifier;

            controller.Move(movementVector * Time.deltaTime);
        }
        else
        {
            rigidbody.AddForce(movementVector * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (enableDebug)
        {
            Debug.Log($"Movement Vector: {movementVector}");
        }
    }

    void DoJump()
    {
        if (usingCharacterController)
        {
            jumpModifier = jumpModifier - jumpDecay * Time.deltaTime;
            if (jumpModifier < 0)
            {
                jumpModifier = 0;
            }

            if (jumpInput && controller.isGrounded)
            {
                jumpModifier = jumpForce;
            }
        }
        else
        {
            if(jumpInput && IsGrounded())
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }


        if (enableDebug)
        {
            Debug.Log($"Jump Modifier: {jumpModifier}");
            if (usingCharacterController)
            {
                Debug.Log($"Is Grounded: {controller.isGrounded}");
            }
            else
            {
                Debug.Log($"Is Grounded: {IsGrounded()}");
            }
        }
    }

    bool IsGrounded()
    {
        int layer = LayerMask.GetMask("Ground");
        return Physics.Raycast(groundChecker.position, Vector3.down, groundedDistance, layer);
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
            projectileInstance.transform.position = projectileSpawn.position;
            projectileInstance.transform.rotation = projectileSpawn.rotation;

            Rigidbody projectileBody = projectileInstance.GetComponent<Rigidbody>();
            if (projectileBody != null)
            {
                Quaternion cameraRotation = Quaternion.AngleAxis(yRotation, Vector3.right);

                Vector3 projectileDirection = cameraRotation * projectileSpawn.forward;
                projectileBody.AddForce(projectileDirection * projectileForce, ForceMode.Impulse);
            }
            else
            {
                if(enableDebug)
                {
                    Debug.Log("Projectile spawned but has no rigid body!");
                }
            }

            Destroy(projectileInstance, projectileLifetime);
        }
    }

    void ShootRocket()
    {
        if (rocketInput)
        {
            GameObject projectileInstance = Instantiate(rocketPrefab);
            projectileInstance.transform.position = projectileSpawn.position;
            projectileInstance.transform.rotation = projectileSpawn.rotation;

            Rigidbody projectileBody = projectileInstance.GetComponent<Rigidbody>();
            if (projectileBody != null)
            {
                Quaternion cameraRotation = Quaternion.AngleAxis(yRotation, Vector3.right);

                Vector3 projectileDirection = cameraRotation * projectileSpawn.forward;
                projectileBody.AddForce(projectileDirection * projectileForce, ForceMode.Impulse);
            }
            else
            {
                if (enableDebug)
                {
                    Debug.Log("Rocket spawned but has no rigid body!");
                }
            }

            Destroy(projectileInstance, projectileLifetime);
        }
    }

    void Interact()
    {
        if(interactInput)
        {
            if (selectedObject == null)
            {
                RaycastHit hitInfo;
                Ray interactionRay = new Ray(camera.position, camera.forward);
                if (Physics.Raycast(interactionRay, out hitInfo, interactionDistance, LayerMask.GetMask("Selectable")))
                {
                    selectedObject = hitInfo.transform.GetComponent<ISelectable>();
                    if (selectedObject != null)
                    {
                        selectedObject.OnInteract();
                        if (selectedObject.ShouldPickup())
                        {
                            selectedObject.OnPickup();
                            selectedObject.GetTransform().SetParent(pickupPivot);
                            selectedObject.GetTransform().localPosition = Vector3.zero;
                            selectedObject.GetTransform().localRotation = Quaternion.identity;
                        }
                        else
                        {
                            selectedObject = null;
                        }
                    }
                }
            }
            else
            {
                selectedObject.OnPutDown();
                selectedObject.GetTransform().SetParent(null);
                selectedObject = null;
            }
        }
    }
}
