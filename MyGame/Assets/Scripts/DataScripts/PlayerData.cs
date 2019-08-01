using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public int bones;
    // public string previousScene;
    public string currentScene;
    public string previousScene;
    public bool firstTimePlaying;
    public float[] position;
    public bool changingScene;

    public PlayerData(PlayerHandler player) {
        health = player.health;
        bones = player.bones;
        currentScene = player.currentScene;
        previousScene = player.currentScene;
        firstTimePlaying = player.firstTimePlaying;
        changingScene = player.changingScene;
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}