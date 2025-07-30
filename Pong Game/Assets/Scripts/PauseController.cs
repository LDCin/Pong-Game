using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _resumeButton;
    [SerializeField] private GameObject _menuButton;
    private void Awake()
    {
        _pauseButton.SetActive(true);
        _resumeButton.SetActive(false);
        _menuButton.SetActive(false);
    }
    public void PauseGame()
    {
        _pauseButton.SetActive(false);
        _resumeButton.SetActive(true);
        _menuButton.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        _pauseButton.SetActive(true);
        _resumeButton.SetActive(false);
        _menuButton.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
