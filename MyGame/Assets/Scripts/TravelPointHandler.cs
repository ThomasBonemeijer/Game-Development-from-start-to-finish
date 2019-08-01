using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TravelPointHandler : MonoBehaviour
{
    public string sceneName;
    public GameObject loadingScreen;
    public Image loadingBar;
    public Text progressText;
    public GameObject useButton;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            useButton.SetActive(true);
            col.gameObject.GetComponent<PlayerHandler>().changingScene = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            useButton.SetActive(false);
            col.gameObject.GetComponent<PlayerHandler>().changingScene = false;
        }
    }
    public void ChangeScene()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
     {
        AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.fillAmount = progress;
            progressText.text = Mathf.Round(progress * 100f) + "%";
            // Debug.Log(progress);
            yield return null;
        }
    }
}
