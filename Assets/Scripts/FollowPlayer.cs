using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private MainManager mainManager;
    private GameObject activePlayer;
    private Vector3 cameraOffset;

    void Awake(){
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        cameraOffset = new Vector3(0,3,-5);
    }
    void LateUpdate()
    {
        activePlayer = mainManager.GetActivePlayer();
        transform.position = activePlayer.transform.position + cameraOffset;
    }
}
