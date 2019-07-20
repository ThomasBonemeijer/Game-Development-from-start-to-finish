using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Animator animator;
    public GameObject BonePrefab;
    public float boneAmmo;
    public Sprite boneHand;
    public Sprite leftHand;
    private bool attckOnCooldown = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boneAmmo = GameObject.Find("Player").GetComponent<PlayerHandler>().bones;
        if (boneAmmo >= 1) {
            GameObject.Find("Lefthand").GetComponent<SpriteRenderer>().sprite = boneHand;
        } else
        {
            GameObject.Find("Lefthand").GetComponent<SpriteRenderer>().sprite = leftHand;
        }
    }

    public void Shoot() {
        if(boneAmmo != 0f && attckOnCooldown == false) {
            StartCoroutine(Cooldown());
            animator.SetTrigger("Attack");
            Instantiate(BonePrefab, firePoint.position, firePoint.rotation);
            GameObject.Find("Player").GetComponent<PlayerHandler>().bones -= 1;
        }
    }

    IEnumerator Cooldown()
    {
        attckOnCooldown = true;
        yield return new WaitForSeconds(.5f);
        attckOnCooldown = false;
    }
}
