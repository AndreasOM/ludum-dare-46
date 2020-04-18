using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    public float pathSpeed = 1.0f;    // distance along path per second
    public float pathDistance = 0.0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        pathDistance += Time.deltaTime * pathSpeed;
    }
}
