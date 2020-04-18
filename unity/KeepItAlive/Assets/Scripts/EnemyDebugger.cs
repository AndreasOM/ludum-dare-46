using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class EnemyDebugger : MonoBehaviour
{
    private LevelState _levelState;
    
    public GameObject enemies;
    // Start is called before the first frame update
    void Start()
    {
        _levelState = transform.parent.GetComponent<LevelState>();
        Debug.Log( "EnemyDebugger got LevelState:"+_levelState );

        GameObject level = _levelState.level;
        Debug.Log( "EnemyDebugger got Level:"+level );
        /*
        var levelJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(level, Formatting.None,
            new JsonSerializerSettings()
            { 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        Debug.Log("JSON:"+levelJsonString);
        */
        Transform enemies = level.transform.Find("Enemies");
        Debug.Log( "EnemyDebugger got Enemies:"+enemies );
        {
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(enemies, Formatting.None,
                new JsonSerializerSettings()
                { 
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            Debug.Log("JSON:"+jsonString);
            
        }        
        foreach (Transform child in enemies)
        {
            Debug.Log( "Child "+child+" Position "+child.position );
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(child);
            Debug.Log("JSON:"+jsonString);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
