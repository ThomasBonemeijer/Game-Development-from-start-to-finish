using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject UiCanvas;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public static bool gameIsPaused = false;
    public bool musicIsPlaying = true;
    public Image MusicButton;

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

    public void QuitApp() {
        Application.Quit();
    }

    public void MusicSwitch() {
        musicIsPlaying = !musicIsPlaying;
        if(musicIsPlaying == true) {
            MusicButton.sprite = musicOnSprite;
        } else {
            MusicButton.sprite = musicOffSprite;
        }
    }
}
