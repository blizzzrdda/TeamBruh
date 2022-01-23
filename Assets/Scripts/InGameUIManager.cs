using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public Button respawnButton;
    public PlayerRealControl playerRealControl;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        playerRealControl = GameObject.FindWithTag("Player").GetComponent<PlayerRealControl>();
        respawnButton.onClick.AddListener(RespawnButtonClick);
        _canvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    public void Dead()
    {
        _canvasGroup.DOFade(1, .8f).SetEase(Ease.OutExpo);
    }

    private void RespawnButtonClick()
    {
        playerRealControl.Respawn();
        InputManager.Instance.controlState = 0;
        _canvasGroup.DOFade(0, .8f).SetEase(Ease.OutExpo);
    }
}