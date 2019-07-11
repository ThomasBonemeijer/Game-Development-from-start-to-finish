using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public float health = 100f;
    private Image healthBar;
    private Vector2 spawnPoint = new Vector2(0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
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
}
