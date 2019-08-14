using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.up * 2f, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Player") {
            col.gameObject.GetComponent<PlayerHandler>().hasCollectedTablet = true;
            col.gameObject.GetComponent<PlayerHandler>().SavePlayer();
            Destroy(gameObject);
        }
    }
}
