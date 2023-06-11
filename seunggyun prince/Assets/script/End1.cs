using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End1 : MonoBehaviour
{
    [Header("End1")]
    public bool IsTyping;
    public float TypingSpeed;
    [Header("Text")]
    public int index;
    public List<string> StringList = new List<string>();
    [SerializeField] Text MainText;
    public char[] charArray;
    private bool fadeStarted;
    private float fadeTimer;

    void Start()
    {
        StringList.Add("   -프로그래밍-   UI: 채현비 인게임: 이승균 아웃게임: 강성훈");
        MainText.color = new Color(MainText.color.r, MainText.color.g, MainText.color.b, 0f); 
        StartCoroutine(ShowSubtitle(7f));
    }

    void Update()
    {
        Dialog();
    }

    void Dialog()
    {
        if (fadeStarted)
        {
            Color color = MainText.color;
            if (color.a > 0)
            {
                color.a -= Time.deltaTime;
                MainText.color = color;
            }
        }
    }

    IEnumerator Set_Typing(string t, Text obj)
    {
        string current = "";
        charArray = t.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            IsTyping = true;
            current = current + charArray[i];
            obj.text = current;
            yield return new WaitForSeconds(TypingSpeed);
        }
        IsTyping = false;
        StartCoroutine(FadeOutText(2f));
    }

    IEnumerator ShowSubtitle(float delay)
    {
        yield return new WaitForSeconds(delay);

        Color color = MainText.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime;
            MainText.color = color;
            yield return null;
        }

        StartCoroutine(Set_Typing(StringList[index], MainText));
    }

    IEnumerator FadeOutText(float delay)
    {
        yield return new WaitForSeconds(delay);

        Color color = MainText.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime;
            MainText.color = color;
            yield return null;
        }
    }
}