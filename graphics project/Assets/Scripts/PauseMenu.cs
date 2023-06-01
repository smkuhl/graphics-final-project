using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static float curTime;

    public GameObject pauseMenuUI;
    public GameObject playerCamera;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                curTime = Time.timeScale;
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        playerCamera.GetComponent<MouseLook>().enabled = true;
        player.GetComponent<TimeControl>().enabled = true;
        Cursor.visible = false;
        Time.timeScale = curTime;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        playerCamera.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<TimeControl>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadLevelSelect()
    {
        Time.timeScale = 1.0f;
        curTime = Time.timeScale;
        GameIsPaused = false;
        SceneManager.LoadScene("Level Select");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
