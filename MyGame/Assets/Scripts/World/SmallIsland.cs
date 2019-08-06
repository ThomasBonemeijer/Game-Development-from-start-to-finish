using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallIsland : MonoBehaviour
{
    Animator animator;
    public bool canDrop;
    bool isDropping = false;
    public float dropSpeed = 1;
    public float raiseSpeed = 1;
    Vector3 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDrop == true) {
            if (isDropping == true) {
            transform.Translate(Vector3.down * raiseSpeed * Time.deltaTime);
        } else if (isDropping == false) {
            transform.position = Vector3.MoveTowards(transform.position, defaultPos, dropSpeed * Time.deltaTime);
        }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            isDropping = true;
            animator.SetTrigger("Hit");
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            isDropping = false;
        }
    }
}
