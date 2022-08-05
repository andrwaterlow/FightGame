using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interfasemenu : MonoBehaviour
{
  
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private GameObject _panelPaused;

    [SerializeField] private UnityEngine.UI.Button _btnStartGame;
    [SerializeField] private UnityEngine.UI.Button _btnSettings;
    [SerializeField] private UnityEngine.UI.Button _btnQuit;
    [SerializeField] private UnityEngine.UI.Button _btnContinue;

    [SerializeField] private Toggle _tgMute;
    [SerializeField] private Slider _slVolume;

    private bool _mute;
    private int _volume;

   
    private void Awake()
    {
        
        _btnStartGame.onClick.AddListener(StartGame);
        _btnSettings.onClick.AddListener(ShowSettings);
        _btnQuit.onClick.AddListener(QuitGame);
        _btnContinue.onClick.AddListener(Continue);
        _tgMute.onValueChanged.AddListener(SetMute);
        _slVolume.onValueChanged.AddListener(SetVolume);
        _panelPaused.SetActive(false);
        _panelSettings.SetActive(false);

    }

    private void Continue()
    {
        _panelPaused.SetActive(false);
        Time.timeScale = 1;
        
    }

    private void StartGame()
    {
        SceneManager.LoadScene("FirstLevel");
        _panelPaused.SetActive(false);
        _panelSettings.SetActive(false);
        _panelMenu.SetActive(false);

    }
    private void Update()
    {
        if (Time.timeScale <= 0)
        {
            _panelPaused.SetActive(true);
        }
        if (Time.timeScale <= 1)
        {
            _panelPaused.SetActive(false);
        }
    }

    private void QuitGame()
    {
        Application.Quit();

    }

    private void SetMute(bool value)
    {
        _mute = value;
    }

    private void SetVolume(float value)
    {
        _volume = (int) value;
     }

    private void ShowSettings()
    {
        _panelSettings.SetActive(true);
    }

    

}
