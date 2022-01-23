using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReferenceSetter : MonoBehaviour
{
    [SerializeField] private ObjectReference _objectReference;
    
    private void OnEnable()
    {
        _objectReference.SetObjectReference(gameObject);    
    }
}
