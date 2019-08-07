using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    GameObject player;
    public string currentScene;
        // called zero
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // called first
    void OnEnable()
    {
        // Debug.Log("OnEnable called");
        if (player != null) {
            player.GetComponent<PlayerHandler>().LoadPlayer();
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (player != null) {
            player.GetComponent<PlayerHandler>().currentScene = scene.name;
            currentScene = scene.name;

        if (scene.name == "Scene1") {
            if (player.GetComponent<PlayerHandler>().firstTimePlaying == true && player.GetComponent<PlayerHandler>().previousScene == "Scene1") {
                player.transform.position = GameObject.Find("SpawnPointLeft").transform.position;
                Debug.Log("First time playing and previous scene = Scene1");
            } 
            else if (player.GetComponent<PlayerHandler>().firstTimePlaying == false && player.GetComponent<PlayerHandler>().previousScene == "Scene2") {
                player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
                Debug.Log("Not First time playing and previous scene = Scene2");
            }
            else if (player.GetComponent<PlayerHandler>().firstTimePlaying == false && player.GetComponent<PlayerHandler>().previousScene == "Scene3") {
                player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
                Debug.Log("Not First time playing and previous scene = Scene3");
            } else {
                // player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
                Debug.Log("This is the last else");
            }
            
        } else if (scene.name == "Scene2") {
            if(GetComponent<SceneChanger>().changingScene == true) {
                player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
            } 
            else {
                player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
            }
        } else if (scene.name == "Scene3") {
        }
        }
    }

    // called third
    void Start()
    {
        
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
