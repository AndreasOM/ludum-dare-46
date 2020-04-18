using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoseController : MonoBehaviour
{
    public GameObject waterObject;

    public GameObject emitterObject;

    public Vector3 initialSpeed = new Vector3(0.0f, 10.0f, 0.0f);
    public float spawnDelay = 2.0f;

    private float nextSpawnIn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnIn = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawnIn -= Time.deltaTime;
        if (nextSpawnIn <= 0.0f)
        {
            nextSpawnIn = spawnDelay;
            //GameObject eo = gameObject;
            GameObject eo = emitterObject;
//            Quaternion rot = eo.transform.rotation;
            Quaternion rot = Quaternion.identity;
            GameObject wgo = GameObject.Instantiate(waterObject, eo.transform.position, rot, transform);
            Rigidbody rgb = wgo.GetComponent<Rigidbody>();
            Vector3 v = initialSpeed;
            v = gameObject.transform.rotation * v;
            wgo.transform.position = wgo.transform.position + 1.0f*v.normalized;
            rgb.velocity = v;
        }
    }
}
