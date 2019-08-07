using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeEnemyHandler : MonoBehaviour
{
    Animator animator;
    public float health = 100f;
    Image healthBar;
    public GameObject staticBone;
    public GameObject deadBee;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar = transform.Find("BeeHealthBarCanvas").Find("HealthBar").GetComponent<Image>();
    }

    void Update()
    {
        if(health <= 0) {
            BeeDie();
        }
        if (healthBar != null) {
            healthBar.fillAmount = health/100;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name.Contains("Bone")) {
            Destroy(col.gameObject);
            animator.SetTrigger("Hit");
            health -= 25;
            GameObject.Find("Player").GetComponent<PlayerHandler>().bones += 1;
        }
    }

    void BeeDie() {
        Destroy(gameObject);
        Instantiate(staticBone, transform.position, transform.rotation);
        Instantiate(deadBee, transform.position, transform.rotation);
    }
}
