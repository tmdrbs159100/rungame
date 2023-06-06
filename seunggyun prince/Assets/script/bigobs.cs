using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigobs : MonoBehaviour
{
    public GameObject obstaclePrefab; // ������ ��ֹ� ������

    public float spawnInterval = 2f; // ��ֹ� ���� ����6D

    private float spawnTimer; // ��ֹ� ���� Ÿ�̸�

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnInterval = Random.Range(7, 15);
            SpawnObstacle();
            spawnTimer = 0f; // ��ֹ� ���� �� Ÿ�̸Ӹ� �缳��
        }
    }

    private void SpawnObstacle()
    {
        // ��ֹ� ����
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}
