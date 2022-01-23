using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class InstructionFacing : MonoBehaviour
{
    public bool enablePlayerDistanceAlpha;
    
    private Transform _player;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _player = GameObject.Find("PlayerReal").transform;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
        
        if (!enablePlayerDistanceAlpha)
            return;
        _canvasGroup.alpha = Mathf.Clamp01(1.2f - (_player.transform.position - transform.position).magnitude / 5f);
    }
}