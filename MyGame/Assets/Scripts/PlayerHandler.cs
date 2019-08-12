using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public int lives = 3;
    public bool isHit = false;
    public SpriteRenderer[] childrenSprites;
    Image healthBar;
    public float health;
    public int bones = 1;

    public bool firstTimePlaying;
    public string currentScene;
    public string previousScene;
    public Vector3 spawnPoint;
    // public bool changingScene;
    // Start is called before the first frame update
    void Start()
    {
        childrenSprites = GetComponentsInChildren<SpriteRenderer>();
        spawnPoint = transform.position;
        healthBar = GameObject.Find("HealthbarFill").GetComponent<Image>();
    }

    // Update is called once per frame
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
        // changingScene = data.changingScene;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    // Set the players color to red when hit
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
        // changingScene = false;
        SavePlayer();
    }
}
