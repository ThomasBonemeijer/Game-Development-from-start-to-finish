using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RemoveGameObject", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RemoveGameObject() {
        Destroy(gameObject);
    }
}
