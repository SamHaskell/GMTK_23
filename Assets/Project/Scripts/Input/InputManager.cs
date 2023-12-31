using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private PlayerInput _playerInput;
    private PlayerControls _playerControls;
    static public Vector2 MousePosition;
    static public Vector2 MouseDelta;
    static public bool MouseDown;
    static public bool AnyKeyDown;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }

        // _playerInput = GetComponent<PlayerInput>();
        _playerControls = new PlayerControls();
        _playerControls.Enable();

        Cursor.lockState = CursorLockMode.Confined;
        _playerControls.Player.LeftClick.performed += ctx => AudioManager.Instance.PlaySound("click");
    }

    void OnEnable()
    {
        _playerControls.Enable();
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnDisable()
    {
        _playerControls.Disable();
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        var anyKeyAction = _playerControls.Player.AnyKey;
        AnyKeyDown = (anyKeyAction.triggered && anyKeyAction.ReadValue<float>() > 0.0f);
        MousePosition = _playerControls.Player.MousePosition.ReadValue<Vector2>();
        MouseDelta = _playerControls.Player.MouseDelta.ReadValue<Vector2>();
        MouseDown = (_playerControls.Player.LeftClick.ReadValue<float>() > 0.0f);
    }
}
