using System;
using DG.Tweening;
using UnityEngine;

public class PlayerShadowControl : MonoBehaviour
{
    public float horizontalSpeed;
    public float jumpForce;

    private Rigidbody _rigidbody;
    private bool _onGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (InputManager.Instance.controlState != 1)
            return;
        
        HandleMoveHorizontal();
        HandleJump();
    }

    private void HandleMoveHorizontal()
    {
        var x = InputManager.Instance.GetMoveHorizontal() * horizontalSpeed;
        if (Mathf.Abs(x) <= .01f)
            return;
        transform.Translate(x * Vector3.right * Time.deltaTime * horizontalSpeed);
    }

    private void HandleJump()
    {
        if (InputManager.Instance.GetJumpThisFrame() && _onGround)
        {
            _rigidbody.AddForce(jumpForce * Vector3.up);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("ShadowObj"))
        {
            _onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("ShadowObj"))
        {
            _onGround = false;
        }
    }
}