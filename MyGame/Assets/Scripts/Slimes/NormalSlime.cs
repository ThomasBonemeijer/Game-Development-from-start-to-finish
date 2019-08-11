using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSlime : MonoBehaviour
{
    public float health = 100f;
    public bool hasHitPlayer = false;
    SpriteRenderer bodySprite;
    GameObject player;
    public bool playerInRange = false;
    Animator animator;
    public float speed = 1.5f;
    public bool isMoving = true;
    Vector3 idlePosition;
    public float playerDistance;
    public GameObject normalSlimeDead;
    public GameObject slimeSpit;
    Transform spitSpawnpoint1;
    Transform spitSpawnpoint2;
    // Start is called before the first frame update
    void Start()
    {
        spitSpawnpoint1 = transform.Find("SpitSpawnpoint1");
        spitSpawnpoint2 = transform.Find("SpitSpawnpoint2");
        bodySprite = transform.Find("SlimeBody").GetComponent<SpriteRenderer>();
        idlePosition = transform.position;
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        InvokeRepeating("SwitchIsMoving", 0f, .5f);
    }

    void Update()
    {
        FlipSlime();
        playerDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);

        if(playerInRange == true && playerDistance >= 2.7f) {
            SlimeMovement();
            animator.SetBool("Move", true);
        } else if (playerInRange == true && playerDistance <= 2.7f) {
            animator.SetBool("Move", false);
                animator.SetBool("IsAttacking", true);
        } else {
            animator.SetBool("Move", false);
            animator.SetBool("IsAttacking", false);
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
            animator.SetTrigger("Hit");
            bodySprite.color = Color.red;
            health -= 25f;
            Destroy(col.gameObject);
            player.GetComponent<PlayerHandler>().bones += 1;
            StartCoroutine(ResetColor(.2f));
        } else if (col.gameObject.name == "Player" && hasHitPlayer == false) {
            hasHitPlayer = true;
            Attack();
        }
    }

    IEnumerator ResetColor(float time) {
        yield return new WaitForSeconds(time);
        bodySprite.color = Color.white;
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

    void Attack() {
        player.GetComponent<PlayerHandler>().isHit = true;
        StartCoroutine(DamagePlayer(.9f));
    }

    IEnumerator DamagePlayer(float time) {
        yield return new WaitForSeconds(time);
        hasHitPlayer = false;
    }

    void Die() {
        Destroy(gameObject);
        if(gameObject.name.StartsWith("NormalSlime")) {
            Instantiate(normalSlimeDead, transform.position, transform.rotation);
            Instantiate(slimeSpit, spitSpawnpoint1.position, spitSpawnpoint1.rotation);
            Instantiate(slimeSpit, spitSpawnpoint2.position, spitSpawnpoint2.rotation);
        }
    }

    void SwitchIsMoving() {
        isMoving = !isMoving;
    }
}
