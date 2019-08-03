using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornBush : MonoBehaviour
{
    GameObject player;
    void Start() {
        player = GameObject.Find("Player");
    }
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Player") {
            player.GetComponent<PlayerHandler>().health = 0;
        } else if (col.gameObject.name.StartsWith("Bone") || col.gameObject.name.StartsWith("StaticBone")) {
            Destroy(col.gameObject);
            player.GetComponent<PlayerHandler>().bones += 1;
        }
    } 
}
