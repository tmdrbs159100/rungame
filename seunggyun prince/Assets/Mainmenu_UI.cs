using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Mainmenu_UI : MonoBehaviour
{
    private Animator buttonAnimator;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    public void GoGameScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GoMenuScene()
    {
        SceneManager.LoadScene(5);
    }

    public void GoMainMenuScene()
    {
        SceneManager.LoadScene(4);
    }

    public void GoEnd()
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("true");
        buttonAnimator.SetBool("IsHovering", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonAnimator.SetBool("IsHovering", false);
    }
}