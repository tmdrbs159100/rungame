using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    private Image image;
    private bool fadeStarted;
    private float fadeTimer;

    private void Awake() 
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (!fadeStarted)
        {

            fadeTimer += Time.deltaTime;
            if (fadeTimer >= 6f)
            {
                fadeStarted = true;
                fadeTimer = 0f;
            }
        }
        else
        {
            // 이미지 페이드
            Color color = image.color;

            if (color.a > 0)
            {
                color.a -= Time.deltaTime;
            }
            image.color = color;
        }
    }
}