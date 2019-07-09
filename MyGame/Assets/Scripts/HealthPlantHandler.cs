using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlantHandler : MonoBehaviour
{
    public Animator animator;
    private GameObject player;
    private float playerHealth;
    private float resetFruitTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerHandler>().health;
    }

    // Check collision with player
     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && playerHealth < 100f)
        {
            animator.SetBool("IsPlucked", true);
            player.GetComponent<PlayerHandler>().health = 100f;
            Invoke("ResetFruit", resetFruitTime);
        }
    }
    
    private void ResetFruit() {
        animator.SetBool("IsPlucked", false);
    }
}
