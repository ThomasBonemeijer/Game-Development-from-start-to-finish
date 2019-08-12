using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBar;
    public Text progressText;
    public string playerScene;
    bool firstTimePlaying;
    public Image ContinueButton;

    void Start() {
        PlayerData data = SaveSystem.LoadPlayer();
        playerScene = data.currentScene;
        firstTimePlaying = data.firstTimePlaying;
    }

    void Update() {
        if (firstTimePlaying == false) {
            ContinueButton.enabled = true;
        } else {
            ContinueButton.enabled = false;
        }
    }

    public void NewGame(string sceneName)
    {
        StartCoroutine(LoadAsynchronously1(sceneName));
    }

    public void Continue()
    {
        StartCoroutine(LoadAsynchronously2());
    }

    IEnumerator LoadAsynchronously1(string sceneName)
     {
        AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.fillAmount = progress;
            progressText.text = Mathf.Round(progress * 100f) + "%";
            yield return null;
        }
    }

    IEnumerator LoadAsynchronously2()
     {
        AsyncOperation operation = SceneManager.LoadSceneAsync (playerScene);
        loadingScreen.SetActive(true);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.fillAmount = progress;
            progressText.text = Mathf.Round(progress * 100f) + "%";
            yield return null;
        }
    }
}
