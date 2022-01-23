using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; set; }
    
    /// <summary>
    /// Determine what is being controlled currently with input.
    /// 0: PlayerReal, 1: PlayerShadow, 2: LightSource
    /// </summary>
    public int controlState;
    public Animator cameraAnimator;
    
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
        controlState = 0;
    }

    private void OnEnable()
    {
        _moveHorizontal = _playerInputMap.PlayerControl.MoveHorizontal;
        _moveVertical = _playerInputMap.PlayerControl.MoveVertical;
        _playerInputMap.PlayerControl.Enable();
    }

    private void OnDisable()
    {
        _playerInputMap.PlayerControl.Disable();
    }

    public void BlendCamera()
    {
        if (controlState == 0)
            cameraAnimator.Play("Player");
        if (controlState == 2)
            cameraAnimator.Play("Light");
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

    public bool GetInteractThisFrame()
    {
        return _playerInputMap.PlayerControl.Interact.triggered;
    }

    public float GetMoveInOut()
    {
        return _playerInputMap.PlayerControl.MoveInOut.ReadValue<float>();
    }
}