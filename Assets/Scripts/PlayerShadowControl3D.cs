using System;
using DG.Tweening;
using UnityEngine;

public class PlayerShadowControl3D : MonoBehaviour
{
    public float horizontalSpeed;
    public float jumpForce;

    private Rigidbody _rigidbody;
    private bool _onGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
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
        
        var movement = new Vector3(x, 0, 0);
        // _rigidbody.AddForce(movement * Time.deltaTime);
        transform.Translate(movement * Time.fixedTime);
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
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("Hits on ground");
            _onGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            _onGround = false;
        }
    }
}