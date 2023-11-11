using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SparrowController : PlayerController
{
    private float Energy = 1.0f;

    void FixedUpdate(){
        GetComponent<Animator>().SetBool("grounded", IsGrounded());
        if (!base.IsGrounded() && Energy > 0.0f){
            Energy -= Time.deltaTime;
        } else if (base.IsGrounded() && Energy < 1.0f) {
            Energy += Time.deltaTime * 3;
        }
        Debug.Log(Energy);
    }
    private void OnMouseDown(){
        base.Select(gameObject);
        base.Deselect(GameObject.Find("Pudu"));
    }

    protected override void Jump()
    {
        if (Energy > 0){
            base.Jump();
        }
    }

    
}
