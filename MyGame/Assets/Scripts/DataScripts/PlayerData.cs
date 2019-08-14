using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool firstTimePlaying;
    public bool hasKilledEnemyTree;
    public bool hasCollectedKey;
    public bool hasCollectedTablet;
    public int lives;
    public float health;
    public int bones;
    public string currentScene;
    public string previousScene;
    public float[] position;

    public PlayerData(PlayerHandler player) {
        lives = player.lives;
        health = player.health;
        bones = player.bones;
        currentScene = player.currentScene;
        previousScene = player.currentScene;
        firstTimePlaying = player.firstTimePlaying;
        hasKilledEnemyTree = player.hasKilledEnemyTree;
        hasCollectedKey = player.hasCollectedKey;
        hasCollectedTablet = player.hasCollectedTablet;
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}