using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Animator animator;
    public GameObject BonePrefab;
    public float boneAmmo = 1f;
    public Sprite boneHand;
    public Sprite leftHand;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boneAmmo >= 1f) {
            GameObject.Find("Lefthand").GetComponent<SpriteRenderer>().sprite = boneHand;
        } else
        {
            GameObject.Find("Lefthand").GetComponent<SpriteRenderer>().sprite = leftHand;
        }
    }

    public void Shoot() {
        if(boneAmmo != 0f) {
            animator.SetTrigger("Attack");
            Instantiate(BonePrefab, firePoint.position, firePoint.rotation);
            boneAmmo -= 1f;
        }
    }
}
