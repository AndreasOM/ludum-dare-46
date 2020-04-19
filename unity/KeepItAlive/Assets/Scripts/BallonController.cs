using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonController : MonoBehaviour
{
    public GameObject ballonPrefab;
    private LevelState _levelState;
    private PathPositionHelper _pathPositionHelper;

    private GameObject ballon;

    private Rigidbody _rigidbody;

    private float _distance;
    // Start is called before the first frame update
    void Start()
    {
        _levelState = transform.parent.GetComponent<LevelState>();
        Debug.Log( "BallonController got LevelState:"+_levelState );
        _pathPositionHelper = transform.parent.GetComponent<PathPositionHelper>();
        
        // :TODO: add check for misconfiguration

        Quaternion rot = transform.rotation;
        _distance = 0.0f;
        Vector3 pos = _pathPositionHelper.getPosition(0.0f);    // start
        ballon = GameObject.Instantiate(ballonPrefab, pos, rot, gameObject.transform);
        _rigidbody = ballon.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!_levelState.isGameRunning)
        {
            return;
        }

        
//        Debug.Log( "BallonController got LevelState pathDistance:"+levelState.pathDistance );
        Vector3 oldPos = ballon.transform.position;    // where the ballon is
        
        float closestD = _pathPositionHelper.getClosestDistance(oldPos);
        Vector3 closestPos = _pathPositionHelper.getPosition(closestD);
        Debug.DrawLine(oldPos, closestPos, Color.yellow);
        Debug.DrawLine(closestPos, closestPos+1.0f*Vector3.up, Color.yellow);
        
        if (_pathPositionHelper.isNearOrAfterEnd(closestD))
        {
            _levelState.onBalloonReachedEnd();
            return;
        }
        
        float wantD = _levelState.pathDistance;    // this is where we _should_ be under perfect conditions
        Vector3 wantPos = _pathPositionHelper.getPosition(wantD);    // where we want it to be
        Debug.DrawLine(oldPos, wantPos, Color.red);
        Debug.DrawLine(wantPos, wantPos+1.0f*Vector3.up, Color.red);
        if (wantD - closestD > 100.0f)
        {
            wantD = closestD + 100.0f; // limit the max range, so we ensure we can get around corners
        }
        float canD = Mathf.Lerp(wantD, closestD, 0.9f);
        Vector3 pos = _pathPositionHelper.getPosition(canD);    // where we can it to be
        Vector3 posUp = pos + 2.0f*Vector3.up;
//        ballon.transform.position = pos;
        Debug.DrawLine(pos,posUp,Color.cyan);
        Debug.DrawLine(oldPos,pos,Color.cyan);
        // tell the rigid body where to go!
        // NO! // ballon.transform.position = pos;    // we move the ballon
        Vector3 delta = pos - oldPos;
        delta.y = 0.0f;    // do not add y-velocity, and keep x/z-velocity fixed
        delta = _levelState.balloonSpeed * delta.normalized;

        // enforce height from path!
        Vector3 hardY = ballon.transform.position;
        hardY.y = Mathf.Lerp(closestPos.y,hardY.y, 0.5f);
        ballon.transform.position = hardY;
        
        Debug.DrawLine(oldPos,oldPos+delta,Color.green);
        _rigidbody.velocity = delta;
    }
    public void StartGame()
    {
        Debug.Log( "BallonController::StartGame" );
        
        Quaternion rot = transform.rotation;
        _distance = 0.0f;
        Vector3 pos = _pathPositionHelper.getPosition(0.0f);    // start
        
        ballon.transform.position = pos;
        ballon.transform.rotation = rot;
    }
}
