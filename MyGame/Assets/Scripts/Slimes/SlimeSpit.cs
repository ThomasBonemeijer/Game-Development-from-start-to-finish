using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpit : MonoBehaviour
{
    float forceSpeed = 5f;
    private Rigidbody2D rb2D;
    public GameObject smallSlime;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.right * forceSpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            Destroy(gameObject);
            Instantiate(smallSlime, transform.position, transform.rotation);
        }
    }
}
