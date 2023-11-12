using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuduController : PlayerController
{
    private void OnMouseDown(){
        base.mainManager.Select(gameObject);
        base.mainManager.Deselect(GameObject.Find("Sparrow"));
    }

    protected override void Jump(){       
        if (base.IsGrounded()){
            base.Jump();
        }
    }

    
}
