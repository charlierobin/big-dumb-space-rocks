using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class RockMaker2 : MonoBehaviour
{
    public bool refresh = false;
    public bool reset = false;

    public bool backedUp = false;

    public Vector3[] origVertices;

    void Update()
    {
        if(!this.backedUp)
        {
            this.backedUp = true;

            Mesh mesh = GetComponent<MeshFilter>().sharedMesh;

            this.origVertices = mesh.vertices;
        }

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

           
            Vector3[] newVertices = new Vector3[this.origVertices.Length];


            newVertices[0] = this.origVertices[0] * 1.2f;

            


            for (int i = 1; i < this.origVertices.Length; i++)
            {
                newVertices[i] = this.origVertices[i];

            }



            Mesh mesh = GetComponent<MeshFilter>().mesh;

            mesh.vertices = newVertices;

            mesh.RecalculateBounds();


        }
    }
}
