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
        Anim.SetBool("Attack", value);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine(DamageEffect());
        }
    }

    IEnumerator DamageEffect()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
    }
}

