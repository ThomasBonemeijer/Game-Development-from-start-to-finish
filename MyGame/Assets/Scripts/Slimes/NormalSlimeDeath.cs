using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSlimeDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RemoveGameObject", 1);
    }

    void RemoveGameObject() {
        Destroy(gameObject);
    }
}
