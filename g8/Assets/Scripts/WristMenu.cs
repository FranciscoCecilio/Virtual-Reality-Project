using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristMenu : MonoBehaviour
{
    public GameObject wristUI;
    public bool activeWristUI = false;

    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();
    }

    
    public void DisplayWristUI(){
        if(activeWristUI){
            wristUI.SetActive(false);
            activeWristUI = false;
        }
        else if(!activeWristUI){
            wristUI.SetActive(true);
            activeWristUI = true;
        }
    }
}
