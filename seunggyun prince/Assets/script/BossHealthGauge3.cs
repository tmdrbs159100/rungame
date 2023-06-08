using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthGauge3 : MonoBehaviour
{
    Image BossHPbar;
    public float maxHealth = 3000f;
    public static float Bosshealth;

    void Start()
    {

        BossHPbar = GetComponent<Image>();
        Bosshealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (BossHPbar != null)
        {
            BossHPbar.fillAmount = Bosshealth / maxHealth;
        }
    }

}
