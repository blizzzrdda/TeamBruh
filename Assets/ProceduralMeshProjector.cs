using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProceduralMeshProjector : MonoBehaviour
{
    public Material mat;
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;

    // Left-Bot, Left-Top, Right-Top, Right-Bot
    [SerializeField] private List<Transform> vertices;
    [SerializeField] private Transform LightSource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateMeshTimer());

        DrawRealityShape();
    }

    private void DrawRealityShape()
    {
        Mesh mesh = new Mesh();

        Vector3[] verticesToProject = new Vector3[4];

        verticesToProject[0] = vertices[0].localPosition;
        verticesToProject[1] = vertices[1].localPosition;
        verticesToProject[2] = vertices[2].localPosition;
        verticesToProject[3] = vertices[3].localPosition;

        mesh.vertices = verticesToProject;

        mesh.triangles = new int[] {0, 1, 2, 0, 2, 3};
    }

    IEnumerator GenerateMeshTimer()
    {
        while (true)
        {
            GenerateProceduralMesh();
            
            yield return new WaitForSeconds(.2f);
        }
    }

    private void GenerateProceduralMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] verticesToProject = new Vector3[4];

        if (!TraceWall(LightSource, vertices[0], out verticesToProject[0])) return;
        if (!TraceWall(LightSource, vertices[1], out verticesToProject[1])) return;
        if (!TraceWall(LightSource, vertices[2], out verticesToProject[2])) return;
        if (!TraceWall(LightSource, vertices[3], out verticesToProject[3])) return;

        mesh.vertices = verticesToProject;

        mesh.triangles = new int[] {0, 1, 2, 0, 2, 3};

        meshRenderer.material = mat;

        meshFilter.mesh = mesh;
        
        meshFilter.transform.rotation = quaternion.identity;
        meshFilter.transform.position = Vector3.zero;
    }

    private bool TraceWall(Transform lightSource, Transform vertex, out Vector3 projectedVertexPosition, float drawDebug = .2f)
    {
        if (Physics.Raycast(lightSource.position, (vertex.position - lightSource.position).normalized * 500f,
                out RaycastHit raycastHit, 500f, LayerMask.GetMask("Wall")))
        {
            projectedVertexPosition = raycastHit.point;
            return true;
        }

        projectedVertexPosition = new Vector3();
        return false;
    }
    
    private void OnDrawGizmos()
    {
        if (!LightSource) return;
        
        Mesh mesh = new Mesh();
    
        Vector3[] verticesToProject = new Vector3[4];
    
        if (!TraceWall(LightSource, vertices[0], out verticesToProject[0])) return;
        if (!TraceWall(LightSource, vertices[1], out verticesToProject[1])) return;
        if (!TraceWall(LightSource, vertices[2], out verticesToProject[2])) return;
        if (!TraceWall(LightSource, vertices[3], out verticesToProject[3])) return;
    
        mesh.vertices = verticesToProject;
    
        mesh.triangles = new int[] {0, 1, 2, 0, 2, 3};
    
        meshRenderer.material = mat;
    
        meshFilter.mesh = mesh;
        
        meshFilter.transform.rotation = quaternion.identity;
        meshFilter.transform.position = Vector3.zero;

    //     Graphics.DrawMeshNow(mesh,
    //         Matrix4x4.TRS(Vector3.zero, quaternion.identity, Vector3.one));
    }
}