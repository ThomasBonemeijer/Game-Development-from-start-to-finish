using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    Image healthBar;
    public float health;
    public int bones = 1;

    public bool firstTimePlaying;
    public string currentScene;
    public string previousScene;
    public Vector3 spawnPoint;
    public bool changingScene;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
        healthBar = GameObject.Find("HealthbarFill").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f || gameObject.transform.position.y < -8f) {
            PlayerHasDied();
        }
        healthBar.fillAmount = health/100;
    }

    private void PlayerHasDied() {
        // Debug.Log("PLAYE DEAD!");
        health = 100f;
        gameObject.transform.position = spawnPoint;
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();
        health = data.health;
        bones = data.bones;
        currentScene = data.currentScene;
        previousScene = data.previousScene;
        firstTimePlaying = data.firstTimePlaying;
        changingScene = data.changingScene;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    public void ResetPlayer() {
        health = 100f;
        bones = 3;
        currentScene = "Scene1";
        previousScene = "";
        changingScene = false;
        SavePlayer();
    }
}
