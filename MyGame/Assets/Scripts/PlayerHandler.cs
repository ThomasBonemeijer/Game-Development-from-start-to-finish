using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public bool firstTimePlaying;
    public bool hasKilledEnemyTree;
    public bool hasCollectedKey;
    public bool hasCollectedTablet;
    public bool isHit = false;
    public int lives = 3;
    public float health;
    public int bones = 1;
    public string currentScene;
    public string previousScene;
    public Vector3 spawnPoint;
    public SpriteRenderer[] childrenSprites;
    Image healthBar;

    void Start()
    {
        childrenSprites = GetComponentsInChildren<SpriteRenderer>();
        spawnPoint = transform.position;
        healthBar = GameObject.Find("HealthbarFill").GetComponent<Image>();
    }

    void Update()
    {
        //check if the player's health has reached 0
        if (health <= 0f || gameObject.transform.position.y < -8f) {
            PlayerHasDied();
        }
        // check if the player has been hit
        if (isHit == true) {
            IsHit();
        }
        healthBar.fillAmount = health/100;
    }

    private void PlayerHasDied() {
        if (lives != 0) {
            lives -= 1;
            health = 100f;
            gameObject.transform.position = spawnPoint;
        } else {
            GameObject.Find("GameMaster").GetComponent<SceneChanger>().toMainMenu = true;
            ResetPlayer();
            SavePlayer();
            GameObject.Find("GameMaster").GetComponent<SceneChanger>().ChangeScene();
        }
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();
        lives = data.lives;
        health = data.health;
        bones = data.bones;
        currentScene = data.currentScene;
        previousScene = data.previousScene;
        firstTimePlaying = data.firstTimePlaying;
        hasKilledEnemyTree = data.hasKilledEnemyTree;
        hasCollectedKey = data.hasCollectedKey;
        hasCollectedTablet = data.hasCollectedTablet;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    // set the players color to red when hit
    void IsHit() {
        foreach (SpriteRenderer childSprite in childrenSprites){
            childSprite.color = Color.red;
        }  
        StartCoroutine(ResetColors(.1f));
        isHit = false;
    }

    IEnumerator ResetColors(float time) {
        yield return new WaitForSeconds(time);

        foreach (SpriteRenderer childSprite in childrenSprites){
            childSprite.color = Color.white;
        } 
    }

    public void ResetPlayer() {
        lives = 3;
        health = 100f;
        bones = 3;
        currentScene = "Scene1";
        previousScene = "";
        firstTimePlaying = true;
        hasKilledEnemyTree = false;
        hasCollectedKey = false;
        hasCollectedTablet = false;
        SavePlayer();
    }
}
