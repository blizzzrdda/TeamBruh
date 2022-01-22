using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowProjector : MonoBehaviour
{
    [SerializeField] private Transform child;
    
    private void Awake()
    {
        child.GetComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
        Vector3 childScale = child.localScale;
        childScale.z = 3f;
        child.localScale = childScale;
    }

    void Start()
    {
        UpdateShadowTransform();
    }

    private void UpdateShadowTransform()
    {
        if (Physics.Linecast(transform.position, transform.forward * 500f + transform.position,
                out RaycastHit raycastHit, LayerMask.GetMask("Default")))
        {
            child.position = raycastHit.point;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.forward * 500f + transform.position);
    }

    private void OnGUI()
    {
        child.GetComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
        Vector3 childScale = child.localScale;
        childScale.z = 3f;
        child.localScale = childScale;
    }
}