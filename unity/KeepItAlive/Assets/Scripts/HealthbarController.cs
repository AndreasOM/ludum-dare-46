using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    public LevelState levelState;    // the UI is outside of the level hierarchy, so just inject it
    public Image healthbarImage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float hp = levelState.getHealthPercentage();
        healthbarImage.fillAmount = hp;
    }
}
