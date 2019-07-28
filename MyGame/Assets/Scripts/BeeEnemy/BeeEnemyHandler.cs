using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeEnemyHandler : MonoBehaviour
{
    Animator animator;
    public float health = 100f; 
    bool hasBeenHit = false;
    Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar = transform.Find("BeeHealthBarCanvas").Find("HealthBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
        }
        if (healthBar != null) {
            healthBar.fillAmount = health/100;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Bone(Clone)" && hasBeenHit == false) {
            animator.SetTrigger("Hit");
            health -= 25;
            hasBeenHit = true;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.name == "Bone(Clone)") {
            hasBeenHit = false;
        }
    }
}
