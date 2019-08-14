using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCave : MonoBehaviour
{
    public bool hasOpenedDoor;
    public BoxCollider2D boxCollider2;
    public GameObject tempButton;

    void Start()
    {
        boxCollider2 = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(hasOpenedDoor == true) {
            boxCollider2.enabled = true;
            // tempButton.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "Player") {
            tempButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.name == "Player") {
            tempButton.SetActive(false);
        }
    }
}
