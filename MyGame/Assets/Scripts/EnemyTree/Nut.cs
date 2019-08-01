using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    public float forceSpeed = 15f;
    public float RotateSpeed = -1.5f;
    private Rigidbody2D rb;
    public GameObject nutShell;
    public GameObject nutHead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * forceSpeed, ForceMode2D.Impulse);
        rb.AddTorque(RotateSpeed, ForceMode2D.Impulse);
        // Physics2D.IgnoreCollision(GameObject.FindWithTag("Nut").GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());
        StartCoroutine(DestroyNut());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            GameObject.Find("Player").GetComponent<PlayerHandler>().health -= 10;
            Destroy(gameObject);
            Instantiate(nutShell, transform.position, transform.rotation);
            Instantiate(nutHead, transform.position, transform.rotation);
        } else {
            Destroy(gameObject);
            Instantiate(nutShell, transform.position, transform.rotation);
            Instantiate(nutHead, transform.position, transform.rotation);
        }
    }

    IEnumerator DestroyNut() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
