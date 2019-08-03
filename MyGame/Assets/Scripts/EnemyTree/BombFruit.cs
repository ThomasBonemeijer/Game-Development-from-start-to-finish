using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFruit : MonoBehaviour
{
    bool playerInBlastRange = false;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            playerInBlastRange = true;
        } else {
            playerInBlastRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            GameObject.Find("Player").GetComponent<PlayerHandler>().health -= 25f;
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);
            
        } else {
            StartCoroutine(DestroyBomb());
        }
    }

    IEnumerator DestroyBomb() {
        yield return new WaitForSeconds(3);
        if (playerInBlastRange == true) {
            GameObject.Find("Player").GetComponent<PlayerHandler>().health -= 25f;
        }
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }
}
