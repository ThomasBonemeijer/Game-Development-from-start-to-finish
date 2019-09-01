using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKey : MonoBehaviour
{
    Rigidbody2D rb2D;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.up * 2f, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Player") {
            FindObjectOfType<AudioManager>().Play("Pop");
            col.gameObject.GetComponent<PlayerHandler>().hasCollectedKey = true;
            col.gameObject.GetComponent<PlayerHandler>().SavePlayer();
            Destroy(transform.parent.gameObject);
        }
    }
}
