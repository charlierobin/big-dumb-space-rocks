using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMaker3 : MonoBehaviour
{
    public bool refresh = false;
    public bool reset = false;

    public Vector3[] origVertices;

    private void Start()
	{
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;

        this.origVertices = mesh.vertices;
    }

    private void Update()
    {
        if (this.reset)
        {
            this.reset = false;

            Mesh mesh = GetComponent<MeshFilter>().mesh;

            mesh.vertices = this.origVertices;

            mesh.RecalculateBounds();
        }

        if (this.refresh)
        {
            this.refresh = false;


            Mesh mesh = GetComponent<MeshFilter>().mesh;

            mesh.vertices = this.origVertices;

            Vector3[] vertices = mesh.vertices;


            vertices[0] = vertices[0] * 1.2f;



            mesh.vertices = vertices;

            mesh.RecalculateBounds();


        }
    }
}
