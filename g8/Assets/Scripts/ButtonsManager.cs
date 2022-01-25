using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    // Button to go back to Main Menu Scene
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
