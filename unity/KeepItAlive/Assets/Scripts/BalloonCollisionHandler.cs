using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollisionHandler : MonoBehaviour
{
    public ParticleSystem projectileCollisionParticleSystem;
    private LevelState _levelState;

    private void Start()
    {
        _levelState = GetComponentInParent<LevelState>();
        // assert null
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            ProjectileData pd = other.gameObject.GetComponent<ProjectileData>();
            
//            Debug.Log("Balloon collision damage "+pd.damage);
            _levelState.onBalloonDamage(pd.damage);
            if (pd.destroyAfterDamage)
            {
                Destroy(other.gameObject);
            }

            if (projectileCollisionParticleSystem)
            {
                ContactPoint cp = other.GetContact(0);
//                Vector3 pos = other.transform.position;
                Vector3 pos = cp.point;
                Vector3 n = cp.normal;
                Quaternion rot = Quaternion.LookRotation( n, Vector3.up);
                
                Debug.DrawLine(pos,pos+n,Color.white,2.0f);
                GameObject.Instantiate(projectileCollisionParticleSystem, pos,
                    rot);
            }
        }
    }
}
