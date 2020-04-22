using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 1.0f;
    public float AngularSpeed = 2.0f;    // deg per sec
    private CharacterController _controller;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        
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

        Vector3 gravity = Vector3.zero;
        if (!_controller.isGrounded)
        {
            gravity = Physics.gravity * Time.deltaTime; // ^2 ?
        }

        move.y = gravity.y;
        
//        Vector3 move = new Vector3(-Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        _controller.Move(move);
//        transform.up = move;
    }

    private void OnCollisionEnter(Collision other)
    {
        // curently not called!
        Debug.Log("PlayerController::OnCollisionEnter");
        if (other.gameObject.CompareTag( "Trap" ))
        {
            ProjectileData pd = other.gameObject.GetComponent<ProjectileData>();
            if (pd.playerShove > 0.0f)
            {
                Vector3 delta = transform.position - other.transform.position;
                delta.ProjectOntoPlane( Vector3.up );
                delta.Normalize();
                _controller.Move(pd.playerShove * delta);
            }
        }
    }

    public void StartGame()
    {
        Debug.Log( "PlayerController::StartGame "+_initialPosition.x+","+_initialPosition.y+","+_initialPosition.z );
        CharacterController cc = gameObject.GetComponent<CharacterController>();
        cc.enabled = false;
        gameObject.transform.position = _initialPosition;
        gameObject.transform.rotation = _initialRotation;
        cc.enabled = true;
    }
}
