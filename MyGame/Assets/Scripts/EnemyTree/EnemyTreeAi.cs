using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTreeAi : MonoBehaviour
{
    public bool isAwake = false;
    public float health = 300f;
    public GameObject healthBar;
    public GameObject bombFruit;
    public GameObject nut;
    public GameObject treeStump;
    public GameObject chestKey;
    public Transform nutFirePoint;
    public Transform[] bombSpawnArray;
    public Animator animator;
    bool istriggered = false;
    GameObject player;
    Image HealthBarHealth;

    void Start()
    {
        player = GameObject.Find("Player");
        HealthBarHealth = healthBar.transform.GetChild(0).GetComponent<Image>();
        nutFirePoint = GameObject.Find("NutFirePoint").transform;

        bombSpawnArray = new Transform[3];
        bombSpawnArray[0] = GameObject.Find("BombSpawn1").transform;
        bombSpawnArray[1] = GameObject.Find("BombSpawn2").transform;
        bombSpawnArray[2] = GameObject.Find("BombSpawn3").transform;
        
        InvokeRepeating("DropBomb", 0, 4);
        InvokeRepeating("ShootNut", 0, 3);
    }
    
    void Update()
    {
        if (isAwake == true) {
            healthBar.SetActive(true);
            HealthBarHealth.fillAmount = health/300;
            transform.Find("EyeFocusLights").gameObject.SetActive(true);
        } else {
            healthBar.SetActive(false);
            transform.Find("EyeFocusLights").gameObject.SetActive(false);
        }

        if(health <= 0) {
            EnemyTreeDead();
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if  (istriggered == false) {
            if (col.gameObject.name == "Player" && col.gameObject.GetComponent<PlayerHandler>().hasKilledEnemyTree == false) {
                FindObjectOfType<AudioManager>().Play("EnemyTreeAwake");
                isAwake = true;
                animator.SetTrigger("IsAwake");
            }
            istriggered = true;
        }
    }

    void DropBomb() {
        if (isAwake == true) {
            int currentBombSpawn = Random.Range(0, 3);
            Instantiate(bombFruit, bombSpawnArray[currentBombSpawn]);
        }
    }

    void ShootNut() {
        if (isAwake == true) {
            Instantiate(nut, nutFirePoint.position, nutFirePoint.rotation);
        }
    }

    void EnemyTreeDead() {
        player.GetComponent<PlayerHandler>().hasKilledEnemyTree = true;
        player.GetComponent<PlayerHandler>().SavePlayer();
        Destroy(transform.gameObject);
        healthBar.SetActive(false);
        treeStump.SetActive(true);
        if (player.GetComponent<PlayerHandler>().hasCollectedKey == false) {
            Instantiate(chestKey, transform.position, transform.rotation);
        }
    }
}
