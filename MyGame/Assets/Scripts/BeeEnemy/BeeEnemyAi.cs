using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BeeEnemyAi : MonoBehaviour
{
    Animator animator;
    public Transform target;
    public Vector3 idlePoint;
    public bool hasReturnedToIdlePoint = true;
    public float speed = 200;
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    public Transform beeEnemyGfx;
    public GameObject firePoint;
    bool PlayerInRadius = false;
    bool PlayerInShootRadius = false;
    public float playerDistance;
    public GameObject poisonBall;

    // Start is called before the first frame update
    void Start()
    {
        // firePoint = transform.Find("ShootPoint").gameObject;
        animator = GetComponent<Animator>();
        target = GameObject.Find("BeeTarget").transform;
        idlePoint = transform.position;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count) {
            reachedEndOfPath = true;
            return;
        } else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }

        if (PlayerInRadius == true) {
            if (target.transform.position.x >= transform.position.x) {
                beeEnemyGfx.localScale = new Vector3(-1f, 1f, 1f);
                // firePoint.transform.rotation = Quaternion.Euler(0, 0, 336.53f);
            } else if (target.transform.position.x <= transform.position.x) {
                beeEnemyGfx.transform.localScale = new Vector3(1f, 1f, 1f);
                // firePoint.transform.rotation = Quaternion.Euler(0, 180, 336.53f);
            } 
        } else if (PlayerInRadius == false) {
             if (rb.velocity.x >= 0.01f) {
                beeEnemyGfx.localScale = new Vector3(-1f, 1f, 1f);
                // firePoint.transform.rotation = Quaternion.Euler(0, 0, 336.53f);
            } else if (rb.velocity.x <= -0.01f) {
                beeEnemyGfx.transform.localScale = new Vector3(1f, 1f, 1f);
                // firePoint.transform.rotation = Quaternion.Euler(0, 180, 336.53f);
            }
        }
    }

    void UpdatePath() {
        playerDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);

        if (playerDistance <= 6f) {
            PlayerInShootRadius = true;
        } else {
            PlayerInShootRadius = false;
        }

        if (PlayerInRadius == true && PlayerInShootRadius == false) {
            if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
            hasReturnedToIdlePoint = false;
        } else if (PlayerInRadius == false && hasReturnedToIdlePoint == false) {
            if (seeker.IsDone())
            seeker.StartPath(rb.position, idlePoint, OnPathComplete);
        } 
        else if (PlayerInRadius == true && PlayerInShootRadius == true) {
            Shoot();
        }
    }

    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
            hasReturnedToIdlePoint = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player") {
            PlayerInRadius = true;
            hasReturnedToIdlePoint = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player") {
            PlayerInRadius = false;
            hasReturnedToIdlePoint = false;
        }
    }

    void Shoot() {
        animator.SetTrigger("Attack");
        Instantiate(poisonBall, firePoint.transform.position, firePoint.transform.rotation);
    }
}
