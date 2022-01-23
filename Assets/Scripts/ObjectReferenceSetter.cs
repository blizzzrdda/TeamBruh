using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReferenceSetter : MonoBehaviour
{
    [SerializeField] private ObjectReference _objectReference;
    [SerializeField] private bool autoDestroy;
    
    private void OnEnable()
    {
        if (autoDestroy && _objectReference.objectReference != gameObject)
            Destroy(_objectReference.objectReference);
        
        _objectReference.SetObjectReference(gameObject);    
    }
}
