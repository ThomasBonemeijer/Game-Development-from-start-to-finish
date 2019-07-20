using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private GameObject player;
        // called zero
    void Awake()
    {
        // Debug.Log("Awake");
        player = GameObject.Find("Player");
    }

    // called first
    void OnEnable()
    {
        // Debug.Log("OnEnable called");
        player.GetComponent<PlayerHandler>().LoadPlayer();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player.GetComponent<PlayerHandler>().currentScene = scene.name;

        if (scene.name == "Scene1") {
            Debug.Log("1");
            if (player.GetComponent<PlayerHandler>().firstTimePlaying == true) {
                player.transform.position = new Vector3(0f, 0f, 0f);
                Debug.Log("First time playing!");
            } 
            else if (player.GetComponent<PlayerHandler>().firstTimePlaying == false && player.GetComponent<PlayerHandler>().previousScene == "Scene2") {
                 player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
                Debug.Log("Not first time playing!");
            }
            else if (player.GetComponent<PlayerHandler>().firstTimePlaying == false && player.GetComponent<PlayerHandler>().previousScene == "Scene3") {
                 player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
                Debug.Log("Not first time playing!");
            }
            
        } else if (scene.name == "Scene2") {
            Debug.Log("2");
            GameObject.Find("Player").GetComponent<PlayerHandler>().firstTimePlaying = false;
        } else if (scene.name == "Scene3") {
            Debug.Log("3");
            GameObject.Find("Player").GetComponent<PlayerHandler>().firstTimePlaying = false;
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
