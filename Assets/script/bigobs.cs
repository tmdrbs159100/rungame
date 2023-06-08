using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigobs : MonoBehaviour
{
    public GameObject obstaclePrefab; // 생성할 장애물 프리팹

    public float spawnInterval = 2f; // 장애물 생성 간격6D

    private float spawnTimer; // 장애물 생성 타이머

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnInterval = Random.Range(7, 15);
            SpawnObstacle();
            spawnTimer = 0f; // 장애물 생성 후 타이머를 재설정
        }
    }

    private void SpawnObstacle()
    {
        // 장애물 생성
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}
