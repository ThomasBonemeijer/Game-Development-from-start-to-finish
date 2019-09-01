using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public float forceSpeed = 15f;
    public float RotateSpeed = -5f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * forceSpeed, ForceMode2D.Impulse);
        rb.AddTorque(RotateSpeed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<PlayerHandler>().bones += 1;
        } else {
            FindObjectOfType<AudioManager>().Play("BoneHit");
        }
    }
}
