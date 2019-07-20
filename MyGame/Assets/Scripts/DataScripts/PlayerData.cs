using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public int bones;
    public string previousScene;
    public bool firstTimePlaying;
    // public float[] position;

    public PlayerData(PlayerHandler player) {
        health = player.health;
        bones = player.bones;
        previousScene = player.currentScene;
        firstTimePlaying = player.firstTimePlaying;
        
        // position = new float[3];

        // position[0] = player.transform.position.x;
        // position[1] = player.transform.position.y;
        // position[2] = player.transform.position.z;
    }
}