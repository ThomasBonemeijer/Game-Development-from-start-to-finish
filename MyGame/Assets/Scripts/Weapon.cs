using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    // public Button fireButton;
    public GameObject BonePrefab;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot() {
        Instantiate(BonePrefab, firePoint.position, firePoint.rotation);
    }
}
