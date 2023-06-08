using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthGauge : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelReplay;
    
    Image healthBar;
    public float maxHealth = 100f;
    public static float health;
    public static bool isGameOver;
    public static bool isRePlay;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (health<= 0 && isGameOver == false)
        {
            isGameOver = true;
            panelGameOver.SetActive(true) ;
            Time.timeScale = 0f;
        }
        if (health <= 0 && isRePlay == false)
        {
            isGameOver = true;
            panelReplay.SetActive(true);
            Time.timeScale = 0f;
        }
        healthBar.fillAmount = health / maxHealth;
    }
    public void ReplayBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}