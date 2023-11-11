using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SparrowController : PlayerController
{
    private float Energy = 0.3f;
    [SerializeField] TextMeshProUGUI speechBubbleText;
    [SerializeField] GameObject speechBubble;

    void FixedUpdate(){
        GetComponent<Animator>().SetBool("grounded", IsGrounded());
        if (!base.IsGrounded() && Energy > 0.0f){
            Energy -= Time.deltaTime;
        } else if (base.IsGrounded() && Energy < 1.0f) {
            Energy += Time.deltaTime * 3;
        }

        if(TaipanInRange()){
            // scared message
        }
    }
    private void OnMouseDown(){
        base.Select(gameObject);
        base.Deselect(GameObject.Find("Pudu"));
    }

    protected override void Jump()
    {
        if (Energy > 0){
            base.Jump();
        } else {
            speechBubble.SetActive(true);
            speechBubbleText.SetText("I'm Tired");
            StartCoroutine(DeactivateSpeechBubble());
        }
    }

    private bool TaipanInRange(){
        return Vector3.Distance(GameObject.Find("Taipan").transform.position, transform.position) < 3.0f;
    }

    IEnumerator DeactivateSpeechBubble(){
        yield return new WaitForSeconds(3);
        speechBubble.SetActive(false);
    }

    
}
