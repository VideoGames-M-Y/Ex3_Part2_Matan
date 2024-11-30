using UnityEngine;
using UnityEngine.InputSystem;

public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] private float speed = 5f;

    [SerializeField] private InputAction move = new InputAction(
        type: InputActionType.Value, expectedControlType: nameof(Vector2));

    private Rigidbody2D rb;

    private Vector2 moveDirection;

    void OnEnable()
    {
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void Awake()
    {
        // Cache the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Read input in Update for responsive input handling
        moveDirection = move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Apply movement in FixedUpdate for physics calculations
        Vector2 movementVector = moveDirection * speed;
        rb.linearVelocity = movementVector;
    }
}
