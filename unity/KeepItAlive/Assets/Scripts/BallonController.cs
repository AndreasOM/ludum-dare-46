using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonController : MonoBehaviour
{
    public GameObject ballonPrefab;
    private LevelState _levelState;
    private PathPositionHelper _pathPositionHelper;

    private GameObject ballon;
    // Start is called before the first frame update
    void Start()
    {
        _levelState = transform.parent.GetComponent<LevelState>();
        Debug.Log( "BallonController got LevelState:"+_levelState );
        _pathPositionHelper = transform.parent.GetComponent<PathPositionHelper>();
        
        // :TODO: add check for misconfiguration

        ballon = GameObject.Instantiate(ballonPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log( "BallonController got LevelState pathDistance:"+levelState.pathDistance );
        float d = _levelState.pathDistance;
        Vector3 pos = _pathPositionHelper.getPosition(d);
//        ballon.transform.position = pos;
        gameObject.transform.position = pos;    // we move ourselves!
    }
}
