using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    private MainManager mainManager;

    void Start(){
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }
    void OnTriggerEnter(){
        if(mainManager.getNumBottles() == mainManager.getScore()){
            mainManager.setGameComplete();
        }
    }
}
