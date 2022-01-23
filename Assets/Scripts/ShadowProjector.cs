using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowProjector : MonoBehaviour
{
    [SerializeField] private Transform child;
    
    private void Awake()
    {
        SyncMesh();
        Vector3 childScale = child.localScale;
        childScale.z = 1f;
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
        SyncMesh();
        Vector3 childScale = child.localScale;
        childScale.z = 1f;
        child.localScale = childScale;
    }

    private void SyncMesh()
    {
        // sync mesh
        GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
        child.GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
        child.GetComponent<MeshFilter>().mesh = GetComponent<MeshFilter>().mesh;
    }
}