using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public enum PaintingType {
    Sound,
    Teleport,
    Spawn 
}


public class GridElement : MonoBehaviour
{
    public Image imageComponent; // component

    public Sprite[] images; // art
    private int currentThemeCode = 0; // 0 - 4 (special)
    
    // Enum
    public PaintingType type; 

    // Simple Prefab
    public GameObject paintingSimplePrefab; 

    // Special Prefabs 
    public GameObject paintingSpecialPrefab;

    // TeleportPainting
    public Material skyboxMat;

    // SpawnPainting
    public GameObject prefabObject;

    // SoudPainting
    public AudioClip clip;



    // function called by WristMenu
    public void SetArt(int themeCode){
        // store the current code
        currentThemeCode = themeCode;
        imageComponent.sprite = images[themeCode];
    }

    // function called by SelectingManager to instatiate paintings
    public int GetThemeCode(){
        return currentThemeCode;
    }
}
