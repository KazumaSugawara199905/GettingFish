using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadgen : MonoBehaviour
{
    public Material material;

    void Start()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            new Vector3()
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
