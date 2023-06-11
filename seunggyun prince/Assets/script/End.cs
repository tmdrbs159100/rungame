using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [Header("End")]
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
        StringList.Add("   -그래픽-   배경: 김의진 그외: 오현서");
        StartCoroutine(Set_Typing(StringList[index], MainText));
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
        else if (!IsTyping)
        {
            fadeTimer += Time.deltaTime;
            if (fadeTimer >= 1.3f)
            {
                fadeStarted = true;
                fadeTimer = 0f;
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
    }
}