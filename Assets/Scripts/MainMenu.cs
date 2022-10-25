using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
using UnityEditor;

public class MainMenu: MonoBehaviour {  
    
    public string sceneName;

    public void StartScene() {  
        SceneManager.LoadScene(sceneName);  
    }

    public void Leave() {
        Application.Quit();
    }
}
