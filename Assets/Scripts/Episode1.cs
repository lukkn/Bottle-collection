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
    private float stepNumber = 0;
    [SerializeField] CinemachineVirtualCamera vcam1;

    void Start(){
        sparrow = GameObject.Find("Sparrow");
        sparrowController = sparrow.GetComponent<SparrowController>();
    }

    void Update(){   
        if (Vector3.Distance(sparrow.transform.position, middleMarker.transform.position) < 0.5){
            stepNumber = 2;
            startTime = Time.time;
        }

        if (stepNumber == 0){
            sparrowController.speak("What a nice day");
            sparrow.GetComponent<Animator>().SetInteger("mood", 1);
            StartCoroutine(nextStepAfter(3));
        } else if (stepNumber == 1){
            vcam1.m_Priority = 1;
            sparrowController.sparrowMoveBetween(startTime, startMarker, middleMarker);
        } else if (stepNumber == 2){
            sparrowController.sparrowMoveBetween(startTime, middleMarker, endMarker);
        }
    }
    void LateUpdate(){
        
        
    }

    IEnumerator nextStepAfter(int seconds){
        yield return new WaitForSeconds(seconds);
        if(stepNumber == 0) {
            stepNumber = 1; 
            sparrowController.deactivateSpeechBubble();
            startTime = Time.time;
        }
    }


}
