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
    private int score = 0;

    public void SetActivePlayer(GameObject player){
        activePlayer = player;
    }

    public GameObject GetActivePlayer(){
        return activePlayer;
    }

    public void increaseScore(){
        score += 1;
        scoreText.SetText("Score: " + score);
    }

}
