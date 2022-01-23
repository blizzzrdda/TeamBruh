using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeConstructor : MonoBehaviour
{
    [SerializeField] private List<Transform> vertices;

    private void OnDrawGizmos()
    {
        if(vertices.Count != 4) return;
        
        Mesh mesh = new Mesh();
    
        Vector3[] verticesToProject = new Vector3[4];
    
        verticesToProject[0] = vertices[0].localPosition;
        verticesToProject[1] = vertices[1].localPosition;
        verticesToProject[2] = vertices[2].localPosition;
        verticesToProject[3] = vertices[3].localPosition;
    
        mesh.vertices = verticesToProject;
        
        mesh.triangles = new int[] {0, 1, 2, 0, 2, 3};
    
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
