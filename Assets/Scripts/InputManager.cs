using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
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

    private void OnEnable()
    {
        _moveHorizontal = _playerInputMap.PlayerControl.MoveHorizontal;
        _moveHorizontal.Enable();

        _moveVertical = _playerInputMap.PlayerControl.MoveVertical;
        _moveVertical.Enable();
    }

    private void OnDisable()
    {
        _moveHorizontal.Disable();
        _moveVertical.Disable();
    }

    public float GetMoveHorizontal()
    {
        return _moveHorizontal.ReadValue<float>();
    }
}