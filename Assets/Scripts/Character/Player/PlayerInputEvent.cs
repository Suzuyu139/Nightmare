using R3;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputEvent : PresenterBase
{
    private InputSystem_Actions _input;

    public Vector2 MoveInput { get; private set; } = Vector2.zero;
    public Vector2 LookInput { get; private set; } = Vector2.zero;
    public bool InteractInput { get; private set; } = false;

    void Awake()
    {
        _input = new InputSystem_Actions();
    }

    void OnEnable()
    {
        _input.Enable();

        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += OnMove;

        _input.Player.Look.performed += OnLook;
        _input.Player.Look.canceled += OnLook;

        _input.Player.Interact.performed += OnInteract;
        _input.Player.Interact.canceled += OnInteract;
    }

    void OnDisable()
    {
        _input.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    void OnLook(InputAction.CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>();
    }

    void OnInteract(InputAction.CallbackContext context)
    {
        InteractInput = context.ReadValueAsButton();
    }
}
