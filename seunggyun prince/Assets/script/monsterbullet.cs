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

        // 3초 후에 Destroy 함수를 호출하여 자신을 제거합니다.
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
