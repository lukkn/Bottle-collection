using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private GameObject activePlayer;
    private int score = 0;

    public void SetActivePlayer(GameObject player){
        activePlayer = player;
    }

    public GameObject GetActivePlayer(){
        return activePlayer;
    }

    public void increaseScore(){
        score += 1;
        Debug.Log("Score:" + score);
    }

}
