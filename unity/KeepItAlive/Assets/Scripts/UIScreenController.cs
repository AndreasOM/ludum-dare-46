using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenController : MonoBehaviour
{
    public GameObject intro;
    public GameObject success;
    public GameObject failure;
    // Start is called before the first frame update
    void Start()
    {
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hide()
    {
        intro.gameObject.SetActive(false);
        success.gameObject.SetActive(false);
        failure.gameObject.SetActive(false);
    }
    public void showIntro()
    {
        intro.gameObject.SetActive(true);
    }
    public void showFailure()
    {
        failure.gameObject.SetActive(true);
    }
    public void showSuccess()
    {
        success.gameObject.SetActive(true);
    }
}
