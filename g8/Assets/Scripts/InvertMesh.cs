using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertMesh : MonoBehaviour
{

    void Invert()
    {
        Mesh m = GetComponent<MeshFilter>().mesh;
        List<int> triangles = new List<int>(m.triangles);
        triangles.Reverse();
        m.triangles = triangles.ToArray();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invert();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
