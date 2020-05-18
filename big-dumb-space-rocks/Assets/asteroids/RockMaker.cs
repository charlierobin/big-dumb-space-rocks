using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class RockMaker : MonoBehaviour
{
    public bool refresh = false;
    //public bool reset = false;

    void Update()
    {
        //if (this.reset)
        //{
        //    this.reset = false;

        //    Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        //    Vector3[] vertices = mesh.vertices;
        //    mesh.vertices = vertices;
        //    mesh.RecalculateBounds();
        //}

        if (this.refresh)
        {
            this.refresh = false;

            Mesh mesh = GetComponent<MeshFilter>().mesh;

            Vector3[] vertices = mesh.vertices;

            List<int> skip = new List<int>();

            for (int i = 0; i < vertices.Length; i++)
            {
                if (skip.Contains(i)) continue;

                //Vector3 directionVector3 = vertices[i] - new Vector3();

                //Vector3 newSpot = vertices[i] + (directionVector3.normalized * Random.Range(-0.1f,0.1f));

                //vertices[i] = newSpot;

                int option = Random.Range(0, 3);

                float factor = 1.0f;

                if (option == 0)
                {
                    factor = Random.Range(1.05f, 1.1f);
                }
                else if (option == 1)
                {
                    factor = Random.Range(0.9f, 0.95f);
                }
                else
                {
                    factor = 1.0f;
                }

                Vector3 orig = vertices[i];

                vertices[i] = vertices[i] * factor;

                for (int j = i + 1; j < vertices.Length; j++)
                {
                    if (vertices[j] == orig)
                    {
                        vertices[j] = vertices[i];
                        skip.Add(j);
                    }
                }
            }

            mesh.vertices = vertices;

            mesh.RecalculateBounds();
        }
    }
}
