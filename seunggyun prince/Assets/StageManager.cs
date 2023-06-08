using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{

    public static StageManager instance;
    Image Fade;
    private void Awake() 
    {
        if(instance == null)
            instance = this;
        else 
            Destroy(gameObject);
    }
    private void Start()
    {
        FadeOut();
    }
    public void FadeIn()
    {
        Fade = GameObject.Find("Fade").GetComponent<Image>();
        StartCoroutine(_FadeIn());
    }
    IEnumerator _FadeIn()
    {
        float r = Fade.color.r;
        float g = Fade.color.g;
        float b = Fade.color.b;
        float a = Fade.color.a;

        Color color = new Color(r,g,b,a);
        for(float i = 0; i < 1; i += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            a = i;
            color = new Color(r,g,b,a);
            Fade.color = color;
        }
    }

    public void FadeOut()
    {
        Fade = GameObject.Find("Fade").GetComponent<Image>();
        StartCoroutine(_FadeOut());
    }
    IEnumerator _FadeOut()
    {
        float r = Fade.color.r;
        float g = Fade.color.g;
        float b = Fade.color.b;
        float a = Fade.color.a;

        Color color = new Color(r,g,b,a);
        for(float i = 1; i > 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            a = i;
            color = new Color(r,g,b,a);
            Fade.color = color;
        }
    }
}
