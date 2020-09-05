using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour, IPlayerMovement
{
    [Header("Movement")]
    public float walkSpeed = 6f;
    public float crouchSpeedRemover = 2.5f;
    public float runSpeedAdditionner = 1.5f;

    [Header("Action Settings")] 
    public float JumpForce = 10000;
    public float JumpThrottleTimeMinimum = 2f;

    private Vector2 _input;
    private Vector3 _inputDirection;
    private Vector3 _moveVector;
    private Quaternion _currentRotation;

    private float _jumpTimeThrottle;

    private Rigidbody rb;

    public bool isRunning { get; private set; }
    public bool isCrouching { get; private set; }
    public bool hasJump { get; private set; }

    public Transform GroundObj;
    private bool _isGrounded
    {
        get
        {
            Ray ray = new Ray(GroundObj.position, Vector3.down * 0.2f);
            return Physics.Raycast(ray, 0.3f, LayerMask.GetMask("Ground"));
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            throw new UnityException("No RigidBody define in the element");

        if (GroundObj == null)
            throw new UnityException("No ground object attached to the element");
    }

    void FixedUpdate()
    {
        float h = _input.x;
        float v = _input.y;

        Vector3 targetInput = new Vector3(h,0, v);
        _inputDirection = Vector3.Lerp(_inputDirection, targetInput, Time.deltaTime * 10f);
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;

        Vector3 desiredDir = camForward * _inputDirection.z + camRight * _inputDirection.x;
        Move(desiredDir);
        Turn(desiredDir);
        Jump();
    }

    private void Move(Vector3 desiredDirection)
    {
        _moveVector.Set(desiredDirection.x, 0f, desiredDirection.z);
        float speed = walkSpeed + (isRunning ? runSpeedAdditionner : 0) - (isCrouching ? crouchSpeedRemover : 0);
        _moveVector = _moveVector * speed * Time.deltaTime;
        rb.MovePosition(transform.position + _moveVector);
    }

    private void Turn(Vector3 desiredDir)
    {
        if ((desiredDir.x > 0.1f || desiredDir.x < -0.1) || (desiredDir.z > 0.1 || desiredDir.z < -0.1))
        {
            _currentRotation = Quaternion.LookRotation(desiredDir);
            rb.MoveRotation(_currentRotation.normalized);
        }
        else
            rb.MoveRotation(_currentRotation.normalized);
    }

    private void Jump()
    {
        if (hasJump && _isGrounded && _jumpTimeThrottle > JumpThrottleTimeMinimum)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Force);
            _jumpTimeThrottle = 0.0f;
            hasJump = false;
        }

        _jumpTimeThrottle += Time.deltaTime;
    }

    #region IPlayerMovement
    public void OnRun(InputAction.CallbackContext context) => isRunning = context.performed;

    public void OnCrouch(InputAction.CallbackContext context) => isCrouching = context.performed;

    public void OnJump(InputAction.CallbackContext context) => hasJump = context.started;

    public void OnMovement(InputAction.CallbackContext context) => _input = context.ReadValue<Vector2>();
    #endregion
}
