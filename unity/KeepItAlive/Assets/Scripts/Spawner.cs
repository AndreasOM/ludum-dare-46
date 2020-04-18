using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    public Vector3 spread = Vector3.zero;
    public int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; ++i)
        {
            Vector3 pos = parent.transform.position;
            pos.x += Random.Range(-spread.x, spread.x);
            pos.y += Random.Range(-spread.x, spread.x);
            pos.z += Random.Range(-spread.x, spread.x);
            GameObject.Instantiate(prefab, pos, Quaternion.identity, parent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
