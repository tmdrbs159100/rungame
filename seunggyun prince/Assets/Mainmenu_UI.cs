using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Mainmenu_UI : MonoBehaviour
{

    [SerializeField] Image MenuPanel;
    public bool IsMenu = false;
    [Header("버튼")]
    [SerializeField] Button StartBtn;
    [SerializeField] Button MenuBtn;
    [SerializeField] Button EndBtn;
    [SerializeField] Button QuitMenuBtn;

    [Header("오디오")]
    private AudioSource audioSource;
    public AudioClip buttonSound;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;

        StartBtn.onClick.AddListener(() => GoGameScene());
        MenuBtn.onClick.AddListener(() => GoMenuScene());
        EndBtn.onClick.AddListener(() => GoEnd());
        QuitMenuBtn.onClick.AddListener(() => QuitMenu());
    }

    public void GoGameScene()
    {
        if (IsMenu == false)
        {
            PlayButtonSound();
            SceneManager.LoadScene(0);
        }
    }

    public void GoMenuScene()
    {
        if (IsMenu == false)
        {
            PlayButtonSound();
            MenuPanel.gameObject.SetActive(true);
            IsMenu = true;
        }
    }
    public void QuitMenu()
    {
        PlayButtonSound();
        MenuPanel.gameObject.SetActive(false);
        IsMenu = false;
    }
    public void GoEnd()
    {
        PlayButtonSound();
        Application.Quit();
        IsMenu = false;
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
