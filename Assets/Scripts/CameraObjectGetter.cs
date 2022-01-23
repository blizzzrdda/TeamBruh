using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraObjectGetter : MonoBehaviour
{
    [SerializeField] private ObjectReference _objectReference;

    private void Awake()
    {
        _objectReference.OnObjectReferneceChanged.AddListener(SetFollowActor);
    }

    private void SetFollowActor(GameObject ActorToFollow)
    {
        GetComponent<CinemachineVirtualCamera>().Follow = ActorToFollow.transform;
    }
}
