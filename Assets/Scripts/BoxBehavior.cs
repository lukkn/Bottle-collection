using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    private MainManager mainManager;

    void Start(){
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }
    void OnTriggerEnter(Collider other){
        if(mainManager.getNumBottles() == mainManager.getScore() && other.gameObject == mainManager.GetActivePlayer()){
            mainManager.setGameComplete();
        }
    }
}
