using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBehavior : MonoBehaviour
{
    private MainManager mainManager;

    void Start(){
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }

    void OnTriggerEnter(){
        Destroy(gameObject);
        mainManager.increaseScore();
        
    }
}
