using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; set; }
    private PlayerInputMap _playerInputMap;
    private InputAction _moveHorizontal;

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

        _playerInputMap.PlayerControl.MoveUp.Enable();
        _playerInputMap.PlayerControl.MoveDown.Enable();
        _playerInputMap.PlayerControl.Jump.Enable();
    }

    private void OnDisable()
    {
        _moveHorizontal.Disable();
        _playerInputMap.PlayerControl.MoveUp.Disable();
        _playerInputMap.PlayerControl.MoveDown.Disable();
        _playerInputMap.PlayerControl.Jump.Disable();
    }

    public float GetMoveHorizontal()
    {
        return _moveHorizontal.ReadValue<float>();
    }

    public int GetMoveVerticalThisFrame()
    {
        if (_playerInputMap.PlayerControl.MoveUp.triggered && !_playerInputMap.PlayerControl.MoveDown.triggered)
        {
            return 1;
        }

        if (!_playerInputMap.PlayerControl.MoveUp.triggered && _playerInputMap.PlayerControl.MoveDown.triggered)
        {
            return -1;
        }

        return 0;
    }

    public bool GetJumpThisFrame()
    {
        return _playerInputMap.PlayerControl.Jump.triggered;
    }
}