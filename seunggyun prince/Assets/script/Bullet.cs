using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
            BossHealthGauge.Bosshealth-= 15f;
        }

    }
}
