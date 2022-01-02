using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _options;

    [Header ("Buttons")]
    [SerializeField] private Button _btnStart;
    [SerializeField] private Button _btnOptions;
    [SerializeField] private Button _btnQuit;
    [SerializeField] private Button _btnBack;

    [SerializeField] private Toggle _tglMute;

    private bool _isMute;

    private void Awake()
    {
        _btnStart.onClick.AddListener(StartGame);
        _btnOptions.onClick.AddListener(ShowOptions);
        _btnQuit.onClick.AddListener(Quit);
        _btnBack.onClick.AddListener(ShowMenu);
        _tglMute.onValueChanged.AddListener(SetMute);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("MazeTest");
    }

    private void ShowOptions()
    {
        _options.SetActive(true);
        _menu.SetActive(false);
    }

    private void ShowMenu()
    {
        _options.SetActive(false);
        _menu.SetActive(true);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void SetMute(bool value)
    {
        _isMute = value;
    }
}
