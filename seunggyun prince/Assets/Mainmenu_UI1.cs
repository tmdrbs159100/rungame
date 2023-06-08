using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu_UI1 : MonoBehaviour
{
    public void GoGameScene() 
    { 
        SceneManager.LoadScene(0);
    }

    public void GoMenuScene()
    {
        SceneManager.LoadScene(5);
    }

    public void GoMainScene()
    {
        SceneManager.LoadScene(4);
    }

    public void GoEnd()
    {
        Application.Quit();
    }
}
