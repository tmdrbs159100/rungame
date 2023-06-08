using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 4f;

    private Rigidbody2D obstacleRigidbody;

    private void Awake()
    {
        obstacleRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // 3초 후에 Destroy 함수를 호출하여 자신을 제거합니다.
        Destroy(gameObject, 15f);
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











