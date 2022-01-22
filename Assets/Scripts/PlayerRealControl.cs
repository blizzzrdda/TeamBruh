using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRealControl : MonoBehaviour
{
    public float horizontalSpeed;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var movement = new Vector3(InputManager.Instance.GetMoveHorizontal() * horizontalSpeed, 0, 0);
        transform.Translate(movement * Time.deltaTime);
    }
}