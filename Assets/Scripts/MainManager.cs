using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private GameObject activePlayer;

    public void SetActivePlayer(GameObject player){
        activePlayer = player;
    }

    public GameObject GetActivePlayer(){
        return activePlayer;
    }

}
