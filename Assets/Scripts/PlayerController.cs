using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected float movementSpeed = 3;
    protected float jumpForce = 5;
    protected bool playerActive;
    protected MainManager mainManager;

    void Start(){
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }

    void Update(){
        if(playerActive && !mainManager.isGameComplete()){ 
            HandleMovement();
            if(Input.GetKeyDown(KeyCode.Space)){Jump();} 
        }
        LimitRange();
    }   

    void FixedUpdate(){
        float speed = Math.Max(GetComponent<Rigidbody>().velocity.x,GetComponent<Rigidbody>().velocity.z);
        GetComponent<Animator>().SetBool("grounded", IsGrounded());
    }

    // helper functions
    protected virtual void Jump(){
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    protected void HandleMovement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * horizontalInput * Time.deltaTime * movementSpeed;

        float verticalInput = Input.GetAxis("Vertical");
        transform.position += Vector3.forward* verticalInput * Time.deltaTime * movementSpeed;

        if(horizontalInput != 0.0f || verticalInput != 0.0f) {
            GetComponent<Animator>().SetFloat("speed", 3.0f);
        } else {
            GetComponent<Animator>().SetFloat("speed", 0.0f);
        }
    }

    protected void Select(GameObject player){
        Debug.Log(gameObject.name + " selected");
        GameObject.Find("Main Manager").GetComponent<MainManager>().SetActivePlayer(player);
        player.transform.GetChild(0).gameObject.SetActive(true); // activate indicator on player
        player.GetComponent<PlayerController>().SetPlayerActive(true); 
    }

    protected void Deselect(GameObject player){
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.GetComponent<PlayerController>().SetPlayerActive(false);
    }

    void SetPlayerActive(bool state){
        playerActive = state;
    }

    protected bool IsGrounded(){
        return GetComponent<Rigidbody>().velocity.y < 0.001 && GetComponent<Rigidbody>().velocity.y > -0.001;
    }

    void LimitRange(){
        float frontLimit = 3.7f;
        float backLimit = 22.0f;
        if (transform.position.z <= frontLimit){
            transform.position = new Vector3(transform.position.x, transform.position.y, frontLimit);
        }
        if (transform.position.z >= backLimit){
            transform.position = new Vector3(transform.position.x, transform.position.y, backLimit);
        }

        float leftLimit = 12.0f;
        float rightLimit = 197.0f;
        if (transform.position.x <= leftLimit){
            transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= rightLimit){
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
        }

        float topLimit = 20.0f;  
        float bottomLimit = 2.0f;
        if (transform.position.y <= bottomLimit){
            transform.position = new Vector3(transform.position.x, bottomLimit, transform.position.z);
        }
        if (transform.position.y >= topLimit){
            transform.position = new Vector3(transform.position.x, topLimit, transform.position.z);
        }

    }

}
