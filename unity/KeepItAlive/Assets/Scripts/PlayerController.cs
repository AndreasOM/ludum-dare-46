using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 1.0f;
    public float AngularSpeed = 2.0f;    // deg per sec
    private CharacterController _controller;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        // rc car controls probably nit what we want :(
        float f = 1.0f*Speed*Input.GetAxis("Vertical");
        float r = AngularSpeed*Input.GetAxis("Horizontal");
//        transform.Rotate( new Vector3( 0, 0,r ));
        transform.Rotate( new Vector3( 0, r,0 ));
        Quaternion rot = transform.rotation;
        
        Vector3 move = Time.deltaTime*new Vector3( 0, 0, f );
        move = rot * move;
    
//        Vector3 move = new Vector3(-Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        _controller.Move(move);
//        transform.up = move;
    }
}
