using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifetimeController : MonoBehaviour
{
    private float _lifetime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_lifetime > 0.0f)
        {
            _lifetime -= Time.deltaTime;
            if (_lifetime < 0.0f)
            {
                // destroy
                Destroy(gameObject);
            }
        }
    }

    void setLifetime(float lifetime)
    {
        _lifetime = lifetime;
    }
}
