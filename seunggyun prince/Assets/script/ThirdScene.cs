using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThirdScene : MonoBehaviour
{
    [Header("ThirdScene")]
    public bool IsTyping; // 타이핑 중 일때는 true, 아닐때는 false를 반환합니다.
    public float TypingSpeed;
    [Header("Text")]
    public int index;
    public List<string> StringList = new List<string>();
    [SerializeField] Text MainText;
    public char[] charArray;
    void Start()
    {
        StringList.Add("그편지에는 이렇게 써있었습니다");
        StartCoroutine(Set_Typing(StringList[index], MainText));
    }

    void Update()
    {
        Dialog();
    }
    void Dialog()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsTyping == false)
            {
                if (index < StringList.Count - 1)
                {
                    index++;
                    StartCoroutine(Set_Typing(StringList[index], MainText));
                }
                else
                {
                    SceneManager.LoadScene("Opening4");
                }
            }
            else
            {
                StopAllCoroutines();
                IsTyping = false;
                MainText.text = StringList[index];
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
    }
}