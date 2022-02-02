using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonsManager : MonoBehaviour
{
    // Button to go back to Main Menu Scene
    public void GoToMainMenu(SelectEnterEventArgs args){
        SceneManager.LoadScene("MainMenu");
    }
}
