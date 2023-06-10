using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float ScrollSpeed;
    [SerializeField] Material Element;
    [SerializeField] Vector2 vec;

    public AudioClip backgroundMusic;
    private AudioSource audioSource;
    private float musicDuration = 30f;
    private bool isMusicPlaying = true;

    private void Start()
    {
        vec = new Vector2(0, 0);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // 배경음악을 루핑하도록 설정
        audioSource.Play(); // 배경음악 재생

        StartCoroutine(StopMusicAfterDelay());
    }

    IEnumerator StopMusicAfterDelay()
    {
        yield return new WaitForSeconds(musicDuration);

        if (isMusicPlaying)
        {
            audioSource.Stop();
            isMusicPlaying = false;
        }
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        vec.x += ScrollSpeed * Time.deltaTime;
        vec.y = 0;
        Element.mainTextureOffset = vec;
    }
}
