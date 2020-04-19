using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenController : MonoBehaviour
{
    
    public Image image;
    public Sprite introSprite;
    public Sprite successSprite;
    public Sprite failureSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        image.gameObject.SetActive( false );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hide()
    {
        image.gameObject.SetActive(false);
    }
    public void showIntro()
    {
        image.sprite = introSprite;
        image.gameObject.SetActive(true);
    }
    public void showFailure()
    {
        image.sprite = failureSprite;
        image.gameObject.SetActive(true);
    }
    public void showSuccess()
    {
        image.sprite = successSprite;
        image.gameObject.SetActive(true);
    }
}
