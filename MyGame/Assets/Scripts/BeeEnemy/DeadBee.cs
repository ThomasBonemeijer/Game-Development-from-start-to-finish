using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RemoveGameObject", 3);
    }

    void RemoveGameObject() {
        Destroy(gameObject);
    }
}
