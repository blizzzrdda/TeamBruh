using System;
using DG.Tweening;
using UnityEngine;

public class PlayerRealControl : MonoBehaviour
{
    public float horizontalSpeed, verticalSpeed;
    public float jumpForce;

    private Rigidbody _rigidbody;
    private bool _onGround;
    private bool _inLightControl;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (InputManager.Instance.controlState == 0)
        {
            HandleMove(); 
            HandleJump();
        }

        if (_inLightControl)
        {
            if (InputManager.Instance.GetInteractThisFrame())
            {
                if (InputManager.Instance.controlState == 0)
                {
                    InputManager.Instance.controlState = 2;
                }
                else
                {
                    InputManager.Instance.controlState = 0;
                }
                InputManager.Instance.BlendCamera();
            }
        }
    }

    private void HandleMove()
    {
        var x = InputManager.Instance.GetMoveHorizontal() * horizontalSpeed;
        var z = InputManager.Instance.GetMoveVertical() * verticalSpeed;
        var movement = new Vector3(x, 0, -z) * Time.deltaTime;
        // _rigidbody.AddForce(movement);
        transform.Translate(movement);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightControl"))
        {
            _inLightControl = true;
            other.gameObject.GetComponentInChildren<LightSourceControl>().Enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LightControl"))
        {
            _inLightControl = false;
            other.gameObject.GetComponentInChildren<LightSourceControl>().Enabled = false;
        }
    }
}