using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false;

    [SerializeField] private GameObject hudCanvas = null;
    [SerializeField] private GameObject pauseCanvas = null;
    [SerializeField] private GameObject settingsCanvas = null;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            SetActivePause(true);
        } else if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            SetActiveSettings(false);
            SetActivePause(false);
        }
    }

    private void Start()
    {
        SetActiveHud(true);
    }

    public void SetActiveHud(bool state)
    {
        hudCanvas.SetActive(state);
        pauseCanvas.SetActive(!state);
    }

    public void SetActivePause(bool state)
    {
        pauseCanvas.SetActive(state);
        hudCanvas.SetActive(!state);

        Time.timeScale = state ? 0 : 1;
        isPaused = state;

        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = state;
    }

    public void SetActiveSettings(bool state)
    {
        settingsCanvas.SetActive(state);
        pauseCanvas.SetActive(!state);
    }


    public void Restart()
    {
        SetActivePause(false);
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Settings()
    {
        SetActiveSettings(true);
    }

    public void Back()
    {
        SetActiveSettings(false);
    }

    public void Resume()
    {
        SetActivePause(false);
    }
}
