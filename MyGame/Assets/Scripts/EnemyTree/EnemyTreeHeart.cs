using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTreeHeart : MonoBehaviour
{
    GameObject player;
    GameObject treeEnemy;
    
    void Start()
    {
        player = GameObject.Find("Player");
        treeEnemy = transform.parent.parent.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name.Contains("Bone")) {
            treeEnemy.GetComponent<EnemyTreeAi>().isAwake = true;
            treeEnemy.GetComponent<EnemyTreeAi>().health -= 50;
            treeEnemy.GetComponent<Animator>().SetTrigger("Hit");
            Destroy(col.gameObject);
            player.GetComponent<PlayerHandler>().bones += 1;
        }
    }
}
