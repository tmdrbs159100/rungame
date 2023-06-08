using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterbullet : MonoBehaviour
{
    public float speed = 4f;
    public float z = 0;

    private Rigidbody2D obstacleRigidbody;
    private Vector2 movementDirection;

    private void Awake()
    {
        obstacleRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float x = transform.rotation.x;
        float y = transform.rotation.y;
        transform.rotation = Quaternion.Euler(x, y, z);

        // 3�� �Ŀ� Destroy �Լ��� ȣ���Ͽ� �ڽ��� �����մϴ�.
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        obstacleRigidbody.velocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            HealthGauge.health -= 15f;
        }
    }
}
