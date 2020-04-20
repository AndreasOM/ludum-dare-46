using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPendulumController : MonoBehaviour
{
    public float maxAngle = 90.0f; 
    public float angularSpeed = 360.0f/5.0f;

    public float _angle;
    private Quaternion _rotation;

    enum State
    {
        SwingToLeft,
        SwingToRight,
    }

    private State _state = State.SwingToLeft;
    // Start is called before the first frame update
    void Start()
    {
        _rotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case State.SwingToLeft:
                {
                    _angle -= angularSpeed * Time.deltaTime;
                    if (_angle < -maxAngle)
                    {
                        _state = State.SwingToRight;
                    }
                }
                break;
            case State.SwingToRight:
                {
                    _angle += angularSpeed * Time.deltaTime;
                    if (_angle > maxAngle)
                    {
                        _state = State.SwingToLeft;
                    }
                }
                break;
        }
        float zRot = _angle;
//        Quaternion rot = transform.rotation;
        Quaternion rot = Quaternion.Euler( 0.0f, 0.0f, zRot);
        transform.rotation = _rotation * rot;
    }
}
