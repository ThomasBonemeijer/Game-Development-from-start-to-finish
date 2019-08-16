using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCaveDoor : MonoBehaviour
{
    GameObject player;
    public Animator animator;
    public Sprite doorOpenSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "Player") {
            if(player.GetComponent<PlayerHandler>().hasCollectedTablet == true) {
                transform.parent.GetComponent<RockCave>().hasOpenedDoor = true;
                GetComponent<SpriteRenderer>().sprite = doorOpenSprite;
                animator.SetTrigger("Open");
            } else {
                Debug.Log("This door requires a tablet");
            }
        }
    }
}
