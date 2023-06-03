using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject projectilePrefab; // 보스가 발사할 프로젝타일 프리팹
    public float attackDelay = 3f; // 공격 주기
    public float projectileSpeed = 10f; // 프로젝타일 속도

    private void Start()
    {
        InvokeRepeating("Attack", attackDelay, attackDelay); // 주기적으로 Attack 메서드를 호출하도록 설정
    }
  

    private void Attack()
    {
        // 보스가 프로젝타일을 발사하는 로직을 여기에 구현

        // 프로젝타일을 생성하고, 고정된 방향으로 발사되도록 설정
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = Vector2.left * projectileSpeed; // 보스의 왼쪽으로 프로젝타일 발사
    }
}