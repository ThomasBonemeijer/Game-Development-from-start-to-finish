using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFruit : MonoBehaviour
{
    bool playerInBlastRange = false;
    public GameObject impactEffect;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            playerInBlastRange = true;
        } else {
            playerInBlastRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            col.gameObject.GetComponent<PlayerHandler>().health -= 25f;
            col.gameObject.GetComponent<PlayerHandler>().isHit = true;
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
            GameObject.Find("Player").GetComponent<PlayerHandler>().isHit = true;
        }
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }
}
