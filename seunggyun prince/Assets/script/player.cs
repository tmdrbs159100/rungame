using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float jumpScale; // 점프 크기 ( 파워 )
    [SerializeField] private bool isGround; // 바닥에 닿았는지 상태

    [Header("GroundCast")]
    [SerializeField] private Vector2 groundCastSize; // 캐릭터 바닥 감지 박스 크기
    [SerializeField] private Vector2 groundCastOffset; // 캐릭터 바닥 감지 박스 위치

    private Rigidbody2D RB;
    private Animator ANIM;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        ANIM = GetComponent<Animator>();
    }
    private void Update()
    {
        Jump();
    }
    private void Jump()
    {
        isGround = Physics2D.BoxCast((Vector2)transform.position + groundCastOffset, groundCastSize, 0f, Vector2.zero, 0f, LayerMask.GetMask("Ground"));

        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.AddForce(Vector2.up * jumpScale, ForceMode2D.Impulse);
            }
            else
                ANIM.SetBool("IsJump", false);
        }
        else
            ANIM.SetBool("IsJump", true);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + groundCastOffset, groundCastSize);
    }
}
