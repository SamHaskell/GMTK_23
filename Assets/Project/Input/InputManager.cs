using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private PlayerInput _playerInput;
    private PlayerControls _playerControls;
    static public Vector2 MousePosition;
    static public Vector2 MouseDelta;
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
        Cursor.visible = false;
    }

    void OnEnable()
    {
        _playerControls.Enable();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true; //TODO: SET FALSE ONCE CURSOR SPRITE CHOSEN;
    }

    void OnDisable()
    {
        _playerControls.Disable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        MousePosition = _playerControls.Player.MousePosition.ReadValue<Vector2>();
        MouseDelta = _playerControls.Player.MouseDelta.ReadValue<Vector2>();
    }
}