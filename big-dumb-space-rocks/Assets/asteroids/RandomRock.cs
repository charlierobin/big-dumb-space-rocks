using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRock : MonoBehaviour
{
    private void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;

        List<int> skip = new List<int>();

        for (int i = 0; i < vertices.Length; i++)
        {
            if (skip.Contains(i)) continue;

            int option = Random.Range(0, 3);

            float factor = 1.0f;

            if (option == 0)
            {
                factor = Random.Range(1.1f, 1.4f);
            }
            else if (option == 1)
            {
                factor = Random.Range(0.6f, 0.9f);
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

        MeshCollider meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }
}
