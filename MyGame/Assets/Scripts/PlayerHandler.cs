using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float health = 100f;
    private Vector2 spawnPoint = new Vector2(0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f || gameObject.transform.position.y < -8f) {
            PlayerHasDied();
        }
    }

    private void PlayerHasDied() {
        // Debug.Log("PLAYE DEAD!");
        health = 100f;
        gameObject.transform.position = spawnPoint;
    }
}
