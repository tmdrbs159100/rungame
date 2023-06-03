using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 4f; 

    private Rigidbody2D obstacleRigidbody;
    private Vector2 movementDirection; 

    private void Awake()
    {
        obstacleRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }
    private void Update()
    {
            obstacleRigidbody.velocity = new Vector2(-speed,0);
    
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



  






