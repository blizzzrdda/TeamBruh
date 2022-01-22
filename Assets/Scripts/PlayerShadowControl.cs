using System;
using DG.Tweening;
using UnityEngine;

public class PlayerShadowControl : MonoBehaviour
{
    public float horizontalSpeed;
    public float jumpForce;

    private Rigidbody2D _rigidbody;
    private bool _onGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMoveHorizontal();
        HandleJump();
    }

    private void HandleMoveHorizontal()
    {
        var x = InputManager.Instance.GetMoveHorizontal() * horizontalSpeed;
        var movement = new Vector3(x, 0, 0);
        transform.Translate(movement * Time.deltaTime);
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = false;
        }
    }
}