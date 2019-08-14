using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool hasCollectedTablet;
    GameObject player;
    public GameObject tablet;
    void Start()
    {
        player = GameObject.Find("Player");
        hasCollectedTablet = player.GetComponent<PlayerHandler>().hasCollectedTablet;
        if (hasCollectedTablet == true) {
            transform.Find("ChestTop").gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "Player" && hasCollectedTablet == false) {
            if(player.GetComponent<PlayerHandler>().hasCollectedKey == true) {
                transform.Find("ChestTop").gameObject.SetActive(false);
                spawnTablet();
            }
        }
    }

    void spawnTablet() {
        Instantiate(tablet, transform.position, transform.rotation);
        hasCollectedTablet = true;
    }
}
