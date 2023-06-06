using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    Animator Anim;
    private void Start() 
    {
        Anim = GetComponent<Animator>();
    }
    public void SetAttackAnim(bool value)
    {
        Anim.SetBool("Attack",value);
    }
    
}
