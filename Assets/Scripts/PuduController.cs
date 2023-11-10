using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuduController : PlayerController
{
    private void OnMouseDown(){
        base.Select(gameObject);
        base.Deselect(GameObject.Find("Sparrow"));
    }

    protected override void Jump(){       
        if (base.IsGrounded()){
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * base.jumpForce, ForceMode.Impulse);
        }
    }

    
}
