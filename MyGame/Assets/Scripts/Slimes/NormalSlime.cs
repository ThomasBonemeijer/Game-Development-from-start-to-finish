using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSlime : MonoBehaviour
{
    float health = 100f;
    GameObject player;
    public bool playerInRange = false;
    Animator animator;
    public float speed = 1.5f;
    public bool isMoving = true;
    Vector3 idlePosition;
    // Start is called before the first frame update
    void Start()
    {
        idlePosition = transform.position;
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        InvokeRepeating("SwitchIsMoving", 0f, .5f);
    }

    void Update()
    {
        if(playerInRange == true) {
            FlipSlime();
            SlimeMovement();
            animator.SetBool("Move", true);
        } else {
            animator.SetBool("Move", false);
        }
        if(health <= 0f) {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            playerInRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name.Contains("Bone")) {
            health -= 25f;
            Destroy(col.gameObject);
            player.GetComponent<PlayerHandler>().bones += 1;
        }
    }

    void SlimeMovement() {
        if(isMoving == true) {
            Vector2 playerPos = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        }
    }

    void FlipSlime() {
        float playerPosX = player.transform.position.x;
        if(transform.position.x < playerPosX) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Die() {
        Destroy(gameObject);
    }

    void SwitchIsMoving() {
        isMoving = !isMoving;
    }
}
