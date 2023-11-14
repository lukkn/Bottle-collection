using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{

    public void startNewGame(){
        SceneManager.LoadScene(1); //Load Level 1
    }
    
    public void loadGame(){

    }
}
