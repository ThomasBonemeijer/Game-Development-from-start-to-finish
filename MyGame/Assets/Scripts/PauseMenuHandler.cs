using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject UiCanvas;
    public static bool gameIsPaused = false;

    public void Resume() {
        pauseMenuCanvas.SetActive(false);
        UiCanvas.SetActive(true);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void Pause() {
        pauseMenuCanvas.SetActive(true);
        UiCanvas.SetActive(false);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void ContinueTime() {
        Time.timeScale = 1;
    }
}
