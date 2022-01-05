using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;

    [Header("Buttons")]
    [SerializeField] private Button _btnPlayAgain;
    [SerializeField] private Button _btnBackToMainMenu;

    private void Awake()
    {
        _deathScreen.SetActive(false);
        _btnPlayAgain.onClick.AddListener(PlayAgain);
        _btnBackToMainMenu.onClick.AddListener(BackToMainMenu);
    }

    private void Update()
    {
        // изменить на  if _curHP <= 0
        if (Input.GetKeyDown(KeyCode.F))
        {
            _deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MazeTest");
    }

    private void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("UI_sample_scene");
    }
}
