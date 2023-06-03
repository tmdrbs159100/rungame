using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float jumpScale; // 점프 크기 ( 파워 )
    [SerializeField] private int maxJumps = 2; // 최대 점프 횟수
    [SerializeField] private bool isGround; // 바닥에 닿았는지 상태
    private int jumpCount; // 현재 점프 횟수

    [Header("GroundCast")]
    [SerializeField] private Vector2 groundCastSize; // 캐릭터 바닥 감지 박스 크기
    [SerializeField] private Vector2 groundCastOffset; // 캐릭터 바닥 감지 박스 위치

    private Rigidbody2D RB;
    private Animator ANIM;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        ANIM = GetComponent<Animator>();
        jumpCount = 0;
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
            jumpCount = 0; // 바닥에 닿으면 점프 횟수 초기화

            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.velocity = new Vector2(RB.velocity.x, jumpScale);
                jumpCount++; // 점프 횟수 증가
            }

            ANIM.SetBool("IsJump", false);
        }
        else
        {
            if (jumpCount < maxJumps && Input.GetKeyDown(KeyCode.Space))
            {
                RB.velocity = new Vector2(RB.velocity.x, jumpScale);
                jumpCount++; // 점프 횟수 증가
            }

            ANIM.SetBool("IsJump", true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + groundCastOffset, groundCastSize);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            ANIM.SetBool("IsHit", true);
        }
    }

    public void SetHitFalse()
    {
        StartCoroutine(WaitAndSetHitFalse());

        IEnumerator WaitAndSetHitFalse()
        {
            yield return new WaitForSeconds(0.5f);
            ANIM.SetBool("IsHit", false);
        }
    }
}

