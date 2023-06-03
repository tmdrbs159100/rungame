using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject projectilePrefab; // ������ �߻��� ������Ÿ�� ������
    public float attackDelay = 3f; // ���� �ֱ�
    public float projectileSpeed = 10f; // ������Ÿ�� �ӵ�

    private void Start()
    {
        InvokeRepeating("Attack", attackDelay, attackDelay); // �ֱ������� Attack �޼��带 ȣ���ϵ��� ����
    }
  

    private void Attack()
    {
        // ������ ������Ÿ���� �߻��ϴ� ������ ���⿡ ����

        // ������Ÿ���� �����ϰ�, ������ �������� �߻�ǵ��� ����
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = Vector2.left * projectileSpeed; // ������ �������� ������Ÿ�� �߻�
    }
}