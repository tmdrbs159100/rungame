using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public AudioClip attackSound; // ���� ���� ����
    public AudioSource audioSource; // ���� ���� ����� ���� AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource ������Ʈ ��������
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, pos.position, transform.rotation);
            PlayAttackSound(); // ���� ���� ���
        }
    }

    void PlayAttackSound()
    {
        audioSource.clip = attackSound; // ����� ���� ���� ����
        audioSource.Play(); // ���� ���
    }
}
