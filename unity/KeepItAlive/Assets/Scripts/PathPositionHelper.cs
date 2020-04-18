using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPositionHelper : MonoBehaviour
{
    public MeshFilter path;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getPosition(float distance)
    {
        Vector3 v;
        
        
        Vector3[] vertices = path.sharedMesh.vertices;
        if (vertices.Length <= 0)
        {
            v = new Vector3();
        }
        else if (vertices.Length == 1)
        {
            v = vertices[0];
        }
        else
        {
            int vi0 = Mathf.FloorToInt(distance);
            float f = distance - vi0;
            
            int vi1 = vi0 + 1;
            vi0 = Mathf.Clamp(vi0, 0, vertices.Length - 1);
            vi1 = Mathf.Clamp(vi1, 0, vertices.Length - 1);

            Vector3 v0 = vertices[vi0];
            Vector3 v1 = vertices[vi1];

            v = Vector3.Lerp(v0, v1, f);

        }

        return v;
    }
}
