using System;
using DG.Tweening;
using UnityEngine;

public class PlayerRealControl : MonoBehaviour
{
    public float horizontalSpeed, verticalSpeed;
    public float jumpForce;
    public int track;

    private Rigidbody _rigidbody;
    private bool _onGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!InputManager.Instance.isControllingReal)
            return;
        
        HandleMoveHorizontal();
        HandleMoveVertical();
        HandleJump();
    }

    private void HandleMoveHorizontal()
    {
        var x = InputManager.Instance.GetMoveHorizontal() * horizontalSpeed;
        var movement = new Vector3(x, 0, 0) * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + transform.TransformDirection(movement));
    }

    private void HandleMoveVertical()
    {
        var z = InputManager.Instance.GetMoveVertical() * verticalSpeed;
        var movement = new Vector3(0, 0, z) * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + transform.TransformDirection(movement));
    }

    private void HandleJump()
    {
        if (InputManager.Instance.GetJumpThisFrame() && _onGround)
        {
            _rigidbody.AddForce(jumpForce * Vector3.up);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = false;
        }
    }
}