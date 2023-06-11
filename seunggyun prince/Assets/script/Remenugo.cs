using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Remenugo : MonoBehaviour
{
    [SerializeField] Button ButtonlogacyBtn;
    private bool buttonHidden = true;

    void Start()
    {
        StartCoroutine(ShowButtonAfterDelay(26f));
        ButtonlogacyBtn.onClick.AddListener(() => {
            SceneManager.LoadScene(5);
        });
    }

    void Update()
    {

    }

    IEnumerator ShowButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ButtonlogacyBtn.gameObject.SetActive(true);
    }
}