using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public AudioClip attackSound; // 공격 사운드 파일
    public AudioSource audioSource; // 공격 사운드 재생을 위한 AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, pos.position, transform.rotation);
            PlayAttackSound(); // 공격 사운드 재생
        }
    }

    void PlayAttackSound()
    {
        audioSource.clip = attackSound; // 재생할 사운드 파일 설정
        audioSource.Play(); // 사운드 재생
    }
}
