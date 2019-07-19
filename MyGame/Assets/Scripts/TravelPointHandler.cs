using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelPointHandler : MonoBehaviour
{
    public string sceneName;
    public GameObject useButton;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            useButton.SetActive(true);
        }else {
            useButton.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            useButton.SetActive(false);
        }
    }

    public void ChangeScene(){
        if (sceneName != "") {
            SceneManager.LoadScene (sceneName);
        }
    }
}
