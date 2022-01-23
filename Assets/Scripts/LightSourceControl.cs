using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceControl : MonoBehaviour
{
    public float horizontalSpeed, verticalSpeed;
    
    private void Update()
    {
        if (InputManager.Instance.controlState != 2)
            return;
        
        Control();
    }

    private void Control()
    {
        var x = InputManager.Instance.GetMoveHorizontal() * horizontalSpeed;
        var y = InputManager.Instance.GetMoveVertical() * verticalSpeed;
        var movement = new Vector3(x, -y, 0) * Time.deltaTime;
        transform.Translate(movement);
    }
}