using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject player;
    public Text AmmoCount;
    float numberOfBones;

    void Update()
    {
        if(player != null) {
            numberOfBones = player.GetComponent<PlayerHandler>().bones;
            AmmoCount.text = numberOfBones.ToString();
        }
    }
}
