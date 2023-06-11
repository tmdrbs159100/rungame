using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button ReStartBtn;
    [SerializeField] Button ButtonlogacyBtn;
    void Start()
    {
        ReStartBtn.onClick.AddListener(()=> {
            SceneManager.LoadScene(1);
        });
        ButtonlogacyBtn.onClick.AddListener(()=> {
            SceneManager.LoadScene(5);
        });
    }

    void Update()
    {
        
    }
}
