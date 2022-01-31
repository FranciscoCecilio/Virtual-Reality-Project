using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public bool optionsActive = false;

    public void NaturalScene(){
        SceneManager.LoadScene("SampleScene");
    }

    public void DarkScene(){
        SceneManager.LoadScene("CosmicGallery");
    }

    public void Quit(){
        Application.Quit();
    }

    public void DisplayOptions(){
        if(!optionsActive){
            optionsActive = true;
            optionsMenu.SetActive(true);
        }
        else{
            optionsActive = false;
            optionsMenu.SetActive(false);
        }

    }
    
}
