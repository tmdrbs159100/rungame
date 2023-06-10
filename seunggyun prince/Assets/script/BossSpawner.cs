using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField]
    private Image bossAppearanceImage = null;

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
        StartCoroutine(BlinkBossAppearanceImage());
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

    private IEnumerator BlinkBossAppearanceImage()
{
    Color initialColor = bossAppearanceImage.color;
    float blinkInterval = 0.1f;
    float blinkDuration = 2.0f;
    float elapsedTime = 0f;

    while (elapsedTime < blinkDuration)
    {
        float alpha = Mathf.PingPong(elapsedTime, blinkDuration) / blinkDuration;
        bossAppearanceImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);

        yield return new WaitForSeconds(blinkInterval);

        elapsedTime += blinkInterval;
    }

    yield return new WaitForSeconds(1.7f); 

    bossAppearanceImage.gameObject.SetActive(false); 
}


    private void Update()
    {
        if (BossHealthGauge.Bosshealth <= 0f && boss != null)
        {
            Destroy(boss);
            StartCoroutine(_FadeIn());
            StartCoroutine(_NextScene());
            boss = null;
        }
    }

    IEnumerator _FadeIn()
    {
        yield return new WaitForSeconds(3);
        StageManager.instance.FadeIn();
    }

    IEnumerator _NextScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
