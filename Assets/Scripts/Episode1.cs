using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using Cinemachine;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Episode1 : MonoBehaviour
{   
    private GameObject sparrow;
    private SparrowController sparrowController;
    private float startTime;
    private int stepNumber = 0;
    private int jumpCount = 0;
    [SerializeField] CinemachineVirtualCamera vcam1;
    [SerializeField] CinemachineVirtualCamera vcam2;

    void Start(){
        sparrow = GameObject.Find("Sparrow");
        sparrowController = sparrow.GetComponent<SparrowController>();
    }

    void Update(){
        Debug.Log(stepNumber);
        switch (stepNumber)
        {
           case 0:
            StartCoroutine(speak());
            break;
           case 1:
            StopCoroutine(speak());
            StartCoroutine(move());
            break;
           case 2:
            StopCoroutine(move());
            StartCoroutine(shock());
            break;
           case 3:
            StopCoroutine(shock());
            StartCoroutine(exclaim());
            break;
           case 4:
            StopCoroutine(exclaim());
            StartCoroutine(anger());
            break;
           case 5:
            StopCoroutine(anger());
            StartCoroutine(leave());
            break;
           case 6:
            StopCoroutine(leave());
            StartCoroutine(scene());
            break;
        }
        
    }

    IEnumerator speak(){
        yield return new WaitForSeconds(1);
        sparrow.GetComponent<Animator>().SetInteger("mood", 1);
        sparrowController.speak("What a nice day");
        stepNumber = 1;
    }

     IEnumerator move(){
        yield return new WaitForSeconds(3);
        sparrowController.deactivateSpeechBubble();
        vcam1.Priority = 1;
        if(jumpCount < 1){
            sparrowController.Jump();
            jumpCount++;
        }
        if (sparrow.transform.position.z > 5.0f){
            sparrowController.HandleMovement(0.0f, -1.0f);
        } else if(sparrow.transform.position.z > 4.0f){
            sparrowController.HandleMovement(1.0f, -1.0f);
        } else {
            sparrowController.HandleMovement(0.0f, 0.0f);
            stepNumber = 2;
        }
    }
        
    IEnumerator shock(){
        yield return new WaitForSeconds(2);
        sparrow.GetComponent<Animator>().SetInteger("mood", 7);
        stepNumber = 3;
    }
    
    IEnumerator exclaim(){
        yield return new WaitForSeconds(1);
        vcam2.Priority = 1;
        sparrowController.speak("What are all these bottles!?");
        stepNumber = 4;
    }

    IEnumerator anger(){
        yield return new WaitForSeconds(3);
        sparrow.GetComponent<Animator>().SetInteger("mood",2);
        sparrowController.speak("I must find out who is behind this!");
        stepNumber = 5;
    }

    IEnumerator leave(){
        yield return new WaitForSeconds(3);
        if (sparrow.transform.position.z > 0.5f){
            sparrowController.HandleMovement(0.0f, -1.0f);
        } else {
            sparrowController.HandleMovement(2.0f,0.0f);
            stepNumber = 6;
        }
    }

    IEnumerator scene(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
