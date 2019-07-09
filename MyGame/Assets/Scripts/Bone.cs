﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public float forceSpeed = 15f;
    public float RotateSpeed = 0;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * forceSpeed, ForceMode2D.Impulse);
        rb.AddTorque(RotateSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyProp());
    }

    IEnumerator DestroyProp()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
