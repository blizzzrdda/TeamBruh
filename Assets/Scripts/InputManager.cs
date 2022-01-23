using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; set; }
    public bool isControllingReal;
    
    private PlayerInputMap _playerInputMap;
    private InputAction _moveHorizontal, _moveVertical;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        _playerInputMap = new PlayerInputMap();
    }

    private void Start()
    {
        isControllingReal = false;
    }

    private void OnEnable()
    {
        _moveHorizontal = _playerInputMap.PlayerControl.MoveHorizontal;
        _moveHorizontal.Enable();

        _moveVertical = _playerInputMap.PlayerControl.MoveVertical;
        _playerInputMap.PlayerControl.MoveVertical.Enable();
        _playerInputMap.PlayerControl.Jump.Enable();
    }

    private void OnDisable()
    {
        _moveHorizontal.Disable();
        _playerInputMap.PlayerControl.MoveVertical.Enable();
        _playerInputMap.PlayerControl.Jump.Disable();
    }

    public float GetMoveHorizontal()
    {
        return _moveHorizontal.ReadValue<float>();
    }

    public float GetMoveVertical()
    {
        return _moveVertical.ReadValue<float>();
    }

    public bool GetJumpThisFrame()
    {
        return _playerInputMap.PlayerControl.Jump.triggered;
    }
}