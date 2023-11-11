using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaipanBehavior : MonoBehaviour
{
    private float range = 3.0f;

    void Update(){
        GetComponent<Animator>().SetBool("puduInRange", PuduInRange());
        GetComponent<Animator>().SetBool("sparrowInRange", SparrowInRange());

    }


    private bool PuduInRange(){
        return Vector3.Distance(GameObject.Find("Pudu").transform.position, transform.position) < range;
    }

    private bool SparrowInRange(){
        return Vector3.Distance(GameObject.Find("Sparrow").transform.position, transform.position) < range;
    }
}
