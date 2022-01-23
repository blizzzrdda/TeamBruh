using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceRegister : MonoBehaviour
{
    [SerializeField] private ObjectReference objectReference;

    private void OnEnable()
    {
        if(objectReference)
            objectReference.SetObjectReference(gameObject);
    }
}
