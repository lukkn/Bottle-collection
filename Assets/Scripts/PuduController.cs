using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuduController : PlayerController
{
    private void OnMouseDown(){
        base.Select(gameObject);
        base.Deselect(GameObject.Find("Sparrow"));
    }
      
}
