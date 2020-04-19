using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    public GameObject level;
    public float pathSpeed = 1.0f;    // distance along path per second
    public float pathDistance = 0.0f;
    public uint maxHealth = 1000;
    public uint currentHealth = 1000;
    void Start()
    {
        
    }

    void Update()
    {
        pathDistance += Time.deltaTime * pathSpeed;
    }

    public float getHealthPercentage()
    {
        return Mathf.Clamp01((float)currentHealth / maxHealth);
    }
}
