using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCreation : MonoBehaviour
{
    Mesh _mesh;
    Vector3[] originalVertices;
    Vector3[] vertices;
    [SerializeField] GameObject _light;
    [SerializeField] float _wallXPos;
    private void Start()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        vertices = _mesh.vertices;
        originalVertices = _mesh.vertices;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vertices.Length; i++)
        //vertices[i] += Vector3.up * Time.deltaTime;
        {
            Vector3 PSL = vertices[i] - _light.transform.position;
            Debug.Log(PSL);
            if (Mathf.Abs(PSL.x) < 0.05)
            {
                vertices[i] = new Vector3(0, 0, 0);
            }
            else 
            {
                vertices[i] = (((_wallXPos-originalVertices[i].x) / PSL.x) * PSL) + originalVertices[i];
                Debug.Log(_wallXPos - vertices[i].x);
                Debug.Log(_wallXPos - vertices[i].x/PSL.x);
                    
            }
        }

        _mesh.vertices = vertices;
        _mesh.RecalculateBounds();
    }
}
