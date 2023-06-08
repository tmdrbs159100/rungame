using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button ReStartBtn;
    void Start()
    {
        ReStartBtn.onClick.AddListener(()=> {
            SceneManager.LoadScene(0);
        });
    }

    void Update()
    {
        
    }
}
