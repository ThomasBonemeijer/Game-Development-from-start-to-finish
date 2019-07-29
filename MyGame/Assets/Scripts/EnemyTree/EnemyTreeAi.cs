using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTreeAi : MonoBehaviour
{
    public GameObject healthBar;
    Image HealthBarHealth;
    bool istriggered = false;
    public bool isAwake = false;
    public Animator animator;
    public GameObject bombFruit;
    public GameObject nut;
    public Transform nutFirePoint;
    public Transform[] bombSpawnArray;
    public float health = 300f;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarHealth = healthBar.transform.GetChild(0).GetComponent<Image>();
        nutFirePoint = GameObject.Find("NutFirePoint").transform;

        bombSpawnArray = new Transform[3];
        bombSpawnArray[0] = GameObject.Find("BombSpawn1").transform;
        bombSpawnArray[1] = GameObject.Find("BombSpawn2").transform;
        bombSpawnArray[2] = GameObject.Find("BombSpawn3").transform;
        
        InvokeRepeating("DropBomb", 0, 4);
        InvokeRepeating("ShootNut", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAwake == true) {
            healthBar.SetActive(true);
            HealthBarHealth.fillAmount = health/100;
        } else {
            healthBar.SetActive(false);
        }

        if(health <= 0) {
            healthBar.SetActive(false);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if  (istriggered == false) {
            if (col.gameObject.name == "Player") {
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
}
