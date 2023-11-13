using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SparrowController : PlayerController
{
    private int Energy = 3;
    private int MaxEnergy = 3;
    [SerializeField] TextMeshProUGUI speechBubbleText;
    [SerializeField] GameObject speechBubble;

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

    protected override void Jump()
    {
        if (Energy > 0){
            base.Jump();
            Energy -= 1;
        } else {
            speechBubble.SetActive(true);
            speechBubbleText.SetText("I'm Tired");
            StartCoroutine(DeactivateSpeechBubble());
        }
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
        StartCoroutine(DeactivateSpeechBubble());
    } 

    IEnumerator DeactivateSpeechBubble(){
            yield return new WaitForSeconds(1);
            speechBubble.SetActive(false);
    }
    
}
