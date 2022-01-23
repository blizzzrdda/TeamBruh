using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ReferenceListener", menuName = "ScriptableObjects/ObjectReference", order = 1)]
public class ObjectReference : ScriptableObject
{
    public GameObject objectReference;

    public void SetObjectReference(GameObject newTransform)
    {
        objectReference = newTransform;
        
        OnObjectReferneceChanged.Invoke(newTransform);
    }
    
    public UnityEvent<GameObject> OnObjectReferneceChanged;
}
