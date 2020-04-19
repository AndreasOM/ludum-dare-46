using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

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

    public bool isNearOrAfterEnd(float distance)
    {
        return distance+5 > path.sharedMesh.vertices.Length;
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

        v = transform.rotation * v;

        return v;
    }

    public float getClosestDistance(Vector3 position)
    {
        Quaternion rot = transform.rotation;              
        
        float minDistance = float.MaxValue;
        float d = 0.0f;
        float bestD = 0.0f;
        foreach (Vector3 v in path.sharedMesh.vertices)
        {
            Vector3 pos = rot * v;    // argl, :TODO: unrotate input
            
            float distance = Vector3.Distance(position, pos);
            if (distance < minDistance)
            {
                minDistance = distance;
                bestD = d;
            }

            d += 1.0f;
        }

        return bestD;
    }
}
