using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TravelPointHandler : MonoBehaviour
{

    public Sprite upImage;
    public Sprite downImage;
    public Sprite leftImage;
    public Sprite rightImage;
    public string theSceneName;
    public GameObject useButton;
    public string direction;
    public GameObject gameMaster;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            useButton.SetActive(true);
            gameMaster.GetComponent<SceneChanger>().sceneName = theSceneName;
            changeUseButtonImage();
            gameMaster.GetComponent<SceneChanger>().changingScene = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            useButton.SetActive(false);
            gameMaster.GetComponent<SceneChanger>().changingScene = false;
        }
    }

    void changeUseButtonImage() {
        if (direction == "up") {
            useButton.GetComponent<Image>().sprite = upImage;
        } else if (direction == "down") {
            useButton.GetComponent<Image>().sprite = downImage;
        } else if (direction == "left") {
            useButton.GetComponent<Image>().sprite = leftImage;
        } else if (direction == "right") {
            useButton.GetComponent<Image>().sprite = rightImage;
        }
    }
}
