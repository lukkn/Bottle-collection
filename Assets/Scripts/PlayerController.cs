using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 3;
    private float jumpForce = 4;
    [SerializeField] private bool playerActive;
    void Update(){
        if(playerActive){ 
            HandleMovement();
            if(Input.GetKeyDown(KeyCode.Space)){Jump();} 
        }
    }   

    // helper functions
    protected void Jump(){
        Debug.Log("Jump");
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    protected void HandleMovement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * horizontalInput * Time.deltaTime * movementSpeed;

        float verticalInput = Input.GetAxis("Vertical");
        transform.position += Vector3.forward* verticalInput * Time.deltaTime * movementSpeed;
    }

    protected void Select(GameObject player){
        Debug.Log(gameObject.name + " selected");
        GameObject.Find("Main Manager").GetComponent<MainManager>().SetActivePlayer(player);
        player.transform.GetChild(0).gameObject.SetActive(true);
        player.GetComponent<PlayerController>().SetPlayerActive(true);
    }

    protected void Deselect(GameObject player){
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.GetComponent<PlayerController>().SetPlayerActive(false);
    }

    void SetPlayerActive(bool state){
        playerActive = state;
    }

    void LimitRange(){
        
    }

}
