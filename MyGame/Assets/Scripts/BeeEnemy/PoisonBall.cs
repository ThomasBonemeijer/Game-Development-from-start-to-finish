using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBall : MonoBehaviour
{
    public float forceSpeed = 15f;
    private Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * forceSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Player") {
            col.GetComponent<PlayerHandler>().health -= 5f;
            col.GetComponent<PlayerHandler>().isHit = true;
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        } else if (col.gameObject.layer == LayerMask.NameToLayer("Ground")){
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
