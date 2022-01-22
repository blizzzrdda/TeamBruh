using System;
using DG.Tweening;
using UnityEngine;

public class PlayerRealControl : MonoBehaviour
{
    public float horizontalSpeed;
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
        HandleMoveHorizontal();
        HandleMoveVertical();
        HandleJump();
    }

    private void HandleMoveHorizontal()
    {
        var x = InputManager.Instance.GetMoveHorizontal() * horizontalSpeed;
        var movement = new Vector3(x, 0, 0);
        transform.Translate(movement * Time.deltaTime);
    }

    private void HandleMoveVertical()
    {
        var value = InputManager.Instance.GetMoveVerticalThisFrame();
        if (value != 0)
        {
            track += value;
            _rigidbody.DOMoveZ(track * 2.5f, .5f).SetEase(Ease.OutExpo);
        }
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