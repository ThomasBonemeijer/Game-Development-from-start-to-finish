using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutProps : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RemoveGameObject", 2);
        rb = transform.GetChild(0).GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * 5, ForceMode2D.Impulse);
        rb.AddTorque(1, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(GameObject.FindWithTag("Nut").GetComponent<Collider2D>(), transform.GetChild(0).GetComponent<Collider2D>());

    }

    void RemoveGameObject() {
        Destroy(gameObject);
    }
}
