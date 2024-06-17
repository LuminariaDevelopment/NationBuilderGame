using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public Material meshMatirial;

    [SerializeField] private Vector3[] vertices;
    [SerializeField] private Vector3[] preVertices;

    public Vector3[] Vertices
    {
        get
        {
            if (vertices != preVertices)
            {
                MakeMesh();
            };
            return vertices;
        }
        set
        {
            if (value != vertices) MakeMesh();
        }
    }
    void Start()
    {

        //     vertices = new Vector3[]
        //    {
        //         new (0, 0,0),
        //         new (1, 0,0),
        //         new (0, 1,0),
        //    };


        MakeMesh();

    }

    private void Update()
    {
        var update = Vertices;
    }


    public void MakeMesh()
    {
        Mesh mesh = new();

        int[] triangle = new int[]
        {
            0, 1, 2,2,1,3
        };

        mesh.vertices = vertices;
        mesh.triangles = triangle;

        GetComponent<MeshFilter>().mesh = mesh;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null && meshMatirial != null)
        {
            meshRenderer.material = meshMatirial;
        }
        else
        {
            throw new Exception("Error");
        }
    }

}
