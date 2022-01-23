using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceControl : MonoBehaviour
{
    public float speed;
    public bool Enabled { get; set; }
    
    private void Update()
    {
        if (InputManager.Instance.controlState != 2 || !Enabled)
            return;
        
        Control();
    }

    private void Control()
    {
        var x = InputManager.Instance.GetMoveHorizontal();
        var y = InputManager.Instance.GetMoveVertical();
        var z = InputManager.Instance.GetMoveInOut();
        var movement = new Vector3(x, -y, z) * Time.deltaTime * speed;
        transform.Translate(movement);
    }
}