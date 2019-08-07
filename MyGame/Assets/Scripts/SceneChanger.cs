using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public GameObject loadingScreen;
    public Image loadingBar;
    public Text progressText;
    public bool changingScene = false;

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
            yield return null;
        }
    }
}
