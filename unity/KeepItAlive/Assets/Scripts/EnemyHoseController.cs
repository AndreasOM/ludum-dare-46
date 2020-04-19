using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Currently not used, nor tested
public class EnemyHoseController : MonoBehaviour
{
    public GameObject waterObject;

    public GameObject emitterObject;

    public Vector3 initialSpeed = new Vector3(0.0f, 10.0f, 0.0f);
    public Vector3 initialSpeedSpread = Vector3.zero;
    public float spawnDelay = 2.0f;

    private float nextSpawnIn = 0.0f;

    private LevelState _levelState;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnIn = spawnDelay;
        _levelState = GetComponentInParent<LevelState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_levelState.isGameRunning)
        {
            return;
        }
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
            v.x = v.x + Random.Range(-initialSpeedSpread.x, initialSpeedSpread.x);
            v.y = v.y + Random.Range(-initialSpeedSpread.y, initialSpeedSpread.y);
            v.z = v.z + Random.Range(-initialSpeedSpread.z, initialSpeedSpread.z);
            v = gameObject.transform.rotation * v;
            wgo.transform.position = wgo.transform.position + 1.0f*v.normalized;
            rgb.velocity = v;

            ProjectileData pd = wgo.GetComponent<ProjectileData>();
            if (pd.lifetime > 0.0f)
            {
                Destroy( wgo, pd.lifetime );
            }
        }
    }
}
