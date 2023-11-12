using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private GameObject activePlayer;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject levelCompleteMenu;
    private int score = 0;
    private int numBottles = 10;
    private bool gameComplete;

    public void SetActivePlayer(GameObject player){
        activePlayer = player;
    }

    public GameObject GetActivePlayer(){
        return activePlayer;
    }

    public void increaseScore(){
        score += 1;
        scoreText.SetText(score + "/" + numBottles);
    }

    public int getScore(){
        return score;
    }

    public int getNumBottles(){
        return numBottles;
    }

    public void setGameComplete(){
        // game complete message
        Debug.Log("Game Complete");
        levelCompleteMenu.SetActive(true);
        gameComplete = true;

    }

    public bool isGameComplete(){
        return gameComplete;
    }

}
