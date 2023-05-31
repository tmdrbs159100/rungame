using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public enum State {  Stand , Run , Jump ,Hit}
    public float startJumpPower;
    public float jumpPower;
    public bool isGround;

    Rigidbody2D rigid;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);

        }
        else if (Input.GetButton("Jump"))
        {
            jumpPower = Mathf.Lerp(jumpPower, 0,0.1f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {

            ChangeAnim(State.Run);

        }
    
        isGround = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        ChangeAnim(State.Jump);
        isGround = false;
    }

    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state);
    }
}
