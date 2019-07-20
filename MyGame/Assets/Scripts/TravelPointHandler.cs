using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelPointHandler : MonoBehaviour
{
    public string sceneName;
    public GameObject useButton;
    public bool isSceneChanger = false;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            useButton.SetActive(true);
            isSceneChanger = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            useButton.SetActive(false);
            isSceneChanger = false;
        }
    }

    public void ChangeScene(){
        if (sceneName != "" && isSceneChanger == true) {
            GameObject.Find("Player").GetComponent<PlayerHandler>().SavePlayer();
            SceneManager.LoadScene (sceneName);
        }
    }
}
