using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparrowController : PlayerController
{
    private void OnMouseDown(){
        base.Select(gameObject);
        base.Deselect(GameObject.Find("Pudu"));
    }   

    
}
