using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SparrowController : PlayerController
{
    private int Energy = 3;
    private int MaxEnergy = 3;
    [SerializeField] private TextMeshProUGUI speechBubbleText;
    [SerializeField] private GameObject speechBubble;
    private bool speechBubbleActive;

    void FixedUpdate(){
        GetComponent<Animator>().SetBool("grounded", IsGrounded());

        /*
        if(TaipanInRange()){
            speechBubble.SetActive(true);
            speechBubbleText.SetText("I'm scared");
            MoveAway(GameObject.Find("Taipan"));
        }
        */

        if(IsGrounded() && Energy < MaxEnergy){
            Energy = MaxEnergy;
        }
    }
    private void OnMouseDown(){
        base.mainManager.Select(gameObject);
        base.mainManager.Deselect(GameObject.Find("Pudu"));
    }

    public override void Jump()
    {
        if (Energy > 0){
            base.Jump();
            Energy -= 1;
        } else {
            speak("I'm Tired", 1);
        }
    }

    public void speak(string message){
        speechBubbleText.SetText(message);
        speechBubble.SetActive(true);
    }
    public void speak(string message, int seconds){
        speak(message);
        StartCoroutine(DeactivateSpeechBubble(seconds));
    }

    public void deactivateSpeechBubble(){
        speechBubble.SetActive(false);
    }

    public void sparrowMoveBetween(float startTime, GameObject startMarker, GameObject endMarker){
        base.moveBetween(startTime, startMarker, endMarker);
    }

    private bool TaipanInRange(){
        return Vector3.Distance(GameObject.Find("Taipan").transform.position, transform.position) < 3.0f;
    }

    private void MoveAway(GameObject other){
        float minDistance = 8.0f;
        float distance = Vector3.Distance(GameObject.Find("Taipan").transform.position, transform.position);
        Vector3 direction = transform.position - other.transform.position;
        direction.Normalize();
        if (distance < minDistance){
            base.setAvoid(true);
            transform.position += (direction * Time.deltaTime * movementSpeed);
        } 
        setAvoid(false);
        StartCoroutine(DeactivateSpeechBubble(1));
    } 

    IEnumerator DeactivateSpeechBubble(int seconds){
            yield return new WaitForSeconds(seconds);
            speechBubble.SetActive(false);
    }
    
}

/*
Sparrow mood:
(0) Neutral
(1) Happy
(2) Annoyed 
(3) Suprised
(4) Excited
(5) Sad
(6) Crying
*/