using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected float movementSpeed {get; private set;}
    protected float jumpForce {get; private set;}
    protected bool playerActive;
    protected MainManager mainManager;
    protected bool avoid;
    

    private Vector3 lastPosition;
    private float positionRecordingInterval = 3;   


    void Start(){
        movementSpeed = 3;
        jumpForce = 5;
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        mainManager.Select(GameObject.Find("Sparrow"));
    }

    void Update(){
        if(playerActive && !mainManager.isGameComplete() && !avoid){ 
            HandleMovement(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
            if(Input.GetKeyDown(KeyCode.Space)){Jump();} 
        } else if (!playerActive){
            FollowActivePlayer();
        }

        RecordLastPosition();
        LimitRange();
    }   

    // helper functions
    protected virtual void Jump(){
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    protected void HandleMovement(float horizontalInput, float verticalInput){

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        if(movement != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        }
        transform.Translate(movement * Time.deltaTime * movementSpeed, Space.World);

        if(horizontalInput != 0.0f || verticalInput != 0.0f) {
            GetComponent<Animator>().SetFloat("speed", 3.0f);
        } else {
            GetComponent<Animator>().SetFloat("speed", 0.0f);
        }
        
    }

    public void SetPlayerActive(bool state){
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

        float topLimit = 40.0f;  
        float bottomLimit = 2.0f;
        if (transform.position.y <= bottomLimit){
            transform.position = new Vector3(transform.position.x, bottomLimit, transform.position.z);
        }
        if (transform.position.y >= topLimit){
            transform.position = new Vector3(transform.position.x, topLimit, transform.position.z);
        }

    }

    protected void FollowActivePlayer(){
        Vector3 activePlayerPos = mainManager.GetActivePlayer().transform.position;
        Vector3 offset = new Vector3(2.0f, 0, 0);
        if (transform.position.x < (activePlayerPos - offset).x){
            HandleMovement(1,0);
            CheckIfStuck();
        } else if (transform.position.x > (activePlayerPos + offset).x){
            HandleMovement(-1,0);
            CheckIfStuck();
        } else {
            HandleMovement(0,0);
        }
    }

    protected void CheckIfStuck(){
        float distance = transform.position.x - mainManager.GetActivePlayer().transform.position.x;
        if (distance > 7.0f || distance < -7.0f){
            Debug.Log("I'm stuck!");
            mainManager.stuckMessage(gameObject);
        }
    }

    protected void RecordLastPosition(){
        if (positionRecordingInterval <= 0){
            positionRecordingInterval = 3;
            lastPosition = transform.position;
        }
        positionRecordingInterval -= Time.deltaTime;
    }


    protected void setAvoid(bool boolean){
        avoid = boolean;
    }

}
