using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using Cinemachine;

public class Episode1 : MonoBehaviour
{   
    private GameObject sparrow;
    private SparrowController sparrowController;
    private float startTime;
    [SerializeField] private GameObject startMarker;
    [SerializeField] private GameObject middleMarker;
    [SerializeField] private GameObject endMarker;
    private int stepNumber = 0;
    [SerializeField] CinemachineVirtualCamera vcam1;
    [SerializeField] CinemachineVirtualCamera vcam2;

    void Start(){
        sparrow = GameObject.Find("Sparrow");
        sparrowController = sparrow.GetComponent<SparrowController>();
    }

    void Update(){   
        if (Vector3.Distance(sparrow.transform.position, middleMarker.transform.position) < 0.5){
            stepNumber = 2;
            startTime = Time.time;
        } else if (sparrow.transform.position == endMarker.transform.position){
            StartCoroutine(nextStepAfter(1, stepNumber));
        }
    }
    void LateUpdate(){
        Debug.Log(stepNumber);
        if (stepNumber == 0){
            sparrowController.speak("What a nice day");
            sparrow.GetComponent<Animator>().SetInteger("mood", 1);
            StartCoroutine(nextStepAfter(3, stepNumber));
        } else if (stepNumber == 1){
            vcam1.m_Priority = 1;
            sparrowController.sparrowMoveBetween(startTime, startMarker, middleMarker);
        } else if (stepNumber == 2){
            sparrowController.sparrowMoveBetween(startTime, middleMarker, endMarker);
        } else if (stepNumber == 3){
            sparrow.GetComponent<Animator>().SetInteger("mood", 7);
            StartCoroutine(nextStepAfter(1, stepNumber));
        } else if (stepNumber == 4 ){
            vcam2.m_Priority = 1;
            sparrowController.speak("What are all these bottles!?");
            
        } else if (stepNumber == 5){

        }
        
    }

    IEnumerator nextStepAfter(int seconds, int step){
        yield return new WaitForSeconds(seconds);
        if(step == 0) {
            stepNumber = 1; 
            sparrowController.deactivateSpeechBubble();
            startTime = Time.time;
        } else if (step == 2){
            stepNumber = 3;
        } else if (step == 3){
            stepNumber = 4;
        }
    }


}
