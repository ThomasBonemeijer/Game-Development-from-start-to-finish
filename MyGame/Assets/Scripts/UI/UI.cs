using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject player;
    public Text ammoCount;
    public Text livesCount;

    void Update()
    {
        if(player != null) {
            ammoCount.text = player.GetComponent<PlayerHandler>().bones.ToString();
            livesCount.text = player.GetComponent<PlayerHandler>().lives.ToString();
        }
    }
}
