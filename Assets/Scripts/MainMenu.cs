using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _controls;

    [Header ("Buttons")]
    [SerializeField] private Button _btnStart;
    [SerializeField] private Button _btnControls;
    [SerializeField] private Button _btnQuit;
    [SerializeField] private Button _btnBack;

    private void Awake()
    {
        _btnStart.onClick.AddListener(StartGame);
        _btnControls.onClick.AddListener(ShowControls);
        _btnQuit.onClick.AddListener(Quit);
        _btnBack.onClick.AddListener(ShowMenu);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("MazeTest");
    }

    private void ShowControls()
    {
        _controls.SetActive(true);
        _menu.SetActive(false);
    }

    private void ShowMenu()
    {
        _controls.SetActive(false);
        _menu.SetActive(true);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
