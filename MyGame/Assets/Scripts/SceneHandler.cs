using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    GameObject player;
    GameObject enemyTree;
    public string currentScene;
    public bool enemyTreeIsDead;
        // called zero
    void Awake()
    {
        player = GameObject.Find("Player");
        enemyTree = GameObject.Find("EnemyTree");
    }

    // called first
    void OnEnable()
    {
        // check if player exists & if so load data
        if (player != null) {
            player.GetComponent<PlayerHandler>().LoadPlayer();
            enemyTreeIsDead = player.GetComponent<PlayerHandler>().hasKilledEnemyTree;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (player != null) {
            player.GetComponent<PlayerHandler>().currentScene = scene.name;
            currentScene = scene.name;

        //Scene 1
        if (scene.name == "Scene1") {

            // check if enemy tree exists and if it has been killed
            
            if (enemyTreeIsDead == true) {
                enemyTree.GetComponent<EnemyTreeAi>().health = 0;
            }
            
            
            // first time playing and previous scene = Scene1
            if (player.GetComponent<PlayerHandler>().firstTimePlaying == true && player.GetComponent<PlayerHandler>().previousScene == "Scene1") {
                player.transform.position = GameObject.Find("SpawnPointLeft").transform.position;
            } 
            // not first time playing and previous scene = Scene2
            else if (player.GetComponent<PlayerHandler>().firstTimePlaying == false && player.GetComponent<PlayerHandler>().previousScene == "Scene2") {
                player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
            }
            // not first time playing and previous scene = Scene3
            else if (player.GetComponent<PlayerHandler>().firstTimePlaying == false && player.GetComponent<PlayerHandler>().previousScene == "Scene3") {
                player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
            }

            //Scene 2    
            } else if (scene.name == "Scene2") {

                // check if player has just changed scenes
                if(GetComponent<SceneChanger>().changingScene == true) {
                    player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
                } 

                // else continue from last position
                else {
                    player.transform.position = GameObject.Find("SpawnPointRight").transform.position;
                }

            //Scene 3
            } else if (scene.name == "Scene3") {
                
            }
        }
    }

    void Start()
    {
        
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
