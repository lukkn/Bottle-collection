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
    [SerializeField] protected GameObject puduIcon;
    [SerializeField] protected GameObject sparrowIcon;
    [SerializeField] protected GameObject stuckMessage;
    private int score = 0;
    private int numBottles = 10;
    private bool gameComplete;
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            GameObject activePlayer = GetActivePlayer();
            if (activePlayer.CompareTag("Pudu")){
                Select(GameObject.Find("Sparrow"));
            } else if (activePlayer.CompareTag("Sparrow")){
                Select(GameObject.Find("Pudu"));
            }
            Deselect(activePlayer);
        }

    }
    public void Select(GameObject player){
        GameObject.Find("Main Manager").GetComponent<MainManager>().SetActivePlayer(player);
        player.transform.GetChild(0).gameObject.SetActive(true); // activate indicator on player
        player.GetComponent<PlayerController>().SetPlayerActive(true); 
    }

    public void Deselect(GameObject player){
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.GetComponent<PlayerController>().SetPlayerActive(false);
    }
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

    public void displayStuckMessage(GameObject gameObject){
        if (gameObject.CompareTag("Pudu")){
            puduIcon.SetActive(true);
        } else if (gameObject.CompareTag("Sparrow")){
            sparrowIcon.SetActive(true);
        }
            stuckMessage.SetActive(true);
    } 

    public void deactivateStuckMessage(){
        puduIcon.SetActive(false);
        sparrowIcon.SetActive(false);
        stuckMessage.SetActive(false);
    }
}
