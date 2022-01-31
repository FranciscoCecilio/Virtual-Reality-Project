using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridElement : MonoBehaviour
{
    public Sprite[] images;
    public Image imageComponent;
    public bool artIsNull;

    public void SetArt(int themeCode){
        if(artIsNull) return;
        imageComponent.sprite = images[themeCode];
    }
}
