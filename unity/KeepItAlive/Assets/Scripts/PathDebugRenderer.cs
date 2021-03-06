﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDebugRenderer : MonoBehaviour
{
    public MeshFilter path;
    public GameObject visual;
    // Start is called before the first frame update
    void Start()
    {
        if( path != null && visual != null )
        {
            Mesh m = path.sharedMesh;
            Vector3[] vertices = m.vertices;
            foreach (var v in vertices)
            {
//                Debug.Log( "v" + v );
//                Quaternion rot = Quaternion.identity;
                Quaternion rot = transform.rotation;              
                Vector3 pos = rot * v;
                GameObject.Instantiate(visual, pos, rot, gameObject.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
