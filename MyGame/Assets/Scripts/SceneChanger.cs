using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public bool toMainMenu = false;
    public bool toReset = false;
    public bool changingScene = false;
    public bool firsttimePlaying;
    GameObject player;
    public string sceneName;
    public GameObject loadingScreen;
    public Image loadingBar;
    public Text progressText;

    void Start() {
        player = GameObject.Find("Player");
    }

    public void ChangeScene()
    {
        if (player != null) {
            player.GetComponent<PlayerHandler>().SavePlayer();
            Debug.Log("Player saved!");
        } else if (player == null) {
            Debug.Log("There is no player gameobject in this scene");
        }

        if (toMainMenu == false && toReset == false) {
            StartCoroutine(LoadAsynchronously());
        } else if (toMainMenu == true && toReset == false) {
            sceneName = "MainMenu";
            StartCoroutine(LoadAsynchronously());
        } else if (toMainMenu == false && toReset == true) {
            sceneName = "Scene1";
            StartCoroutine(LoadAsynchronously());
        }
    }

    IEnumerator LoadAsynchronously()
     {
        if (sceneName != "") {
            AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);
            loadingScreen.SetActive(true);
            while (!operation.isDone) {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                loadingBar.fillAmount = progress;
                progressText.text = Mathf.Round(progress * 100f) + "%";
                yield return null;
            }
        } else {
            Debug.Log("No scene selected");
        }
        toMainMenu = false;
        toReset = false;
    }
}
