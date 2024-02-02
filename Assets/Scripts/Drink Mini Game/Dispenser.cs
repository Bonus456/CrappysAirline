using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dispenser : MonoBehaviour
{
    public Sprite PushSprite;
    private Sprite CurrSprite;
    private Image DispImage;
    public bool PushDown;
    // Start is called before the first frame update
    void Start()
    {
        DispImage = GetComponent<Image>();
        CurrSprite = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(PushDown == true) {
            DispImage.sprite = PushSprite;
		} else {
            DispImage.sprite = CurrSprite;
		}
    }
}
