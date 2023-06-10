using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Mainmenu_UI : MonoBehaviour
{
    private Animator buttonAnimator;
    private AudioSource audioSource;
    public AudioClip buttonSound;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
        audioSource = gameObject.AddComponent<AudioSource>(); // AudioSource ������Ʈ �߰�
        audioSource.clip = buttonSound; // AudioClip �Ҵ�
    }

    public void GoGameScene()
    {
        PlayButtonSound(); // ��ư ���� ���
        SceneManager.LoadScene(0);
    }

    public void GoMenuScene()
    {
        PlayButtonSound(); // ��ư ���� ���
        SceneManager.LoadScene(5);
    }

    public void GoMainMenuScene()
    {
        PlayButtonSound(); // ��ư ���� ���
        SceneManager.LoadScene(4);
    }

    public void GoEnd()
    {
        PlayButtonSound(); // ��ư ���� ���
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonAnimator.SetBool("IsHovering", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonAnimator.SetBool("IsHovering", false);
    }

    private void PlayButtonSound()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
        audioSource.Play();
        Destroy(audioSource, buttonSound.length);
        DontDestroyOnLoad(audioSource);
    }
}
