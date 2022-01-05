using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;

    [Header("Buttons")]
    [SerializeField] private Button _btnBackToMainMenu;
    [SerializeField] private Button _btnResume;

    private void Awake()
    {
        _gameMenu.SetActive(false);
        _btnBackToMainMenu.onClick.AddListener(BackToMainMenu);
        _btnResume.onClick.AddListener(Resume);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gameMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("UI_sample_scene");
    }

    private void Resume()
    {
        _gameMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
