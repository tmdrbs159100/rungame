using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    [SerializeField]
    private float bossSpawnTime = 10.0f;

    [SerializeField]
    private GameObject prefabBoss = null;

    [SerializeField]
    private Transform trStartPos = null;

    [SerializeField]
    private Transform trDestPos = null;

    [SerializeField]
    private float arriveTime = 5.0f;

    private GameObject boss;

    private int secCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnBoss());
        StartCoroutine(DebugTime());
    }

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(bossSpawnTime);

        boss = Instantiate(prefabBoss, trStartPos.position, Quaternion.identity);

        StartCoroutine(MoveBoss());
    }

    private IEnumerator MoveBoss()
    {
        float t = 0f;

        while (t < arriveTime)
        {
            yield return null;

            t += Time.deltaTime;

            if (boss != null)
            {
                boss.transform.position = Vector3.Lerp(trStartPos.position, trDestPos.position, t / arriveTime);
            }
        }
    }


    private IEnumerator DebugTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log($"timeCount : {++secCount}");
        }
    }
    private void Update()
    {
        if (BossHealthGauge.Bosshealth <= 0f && boss != null)
        {
            Destroy(boss);
            boss = null;
        }
    }

}