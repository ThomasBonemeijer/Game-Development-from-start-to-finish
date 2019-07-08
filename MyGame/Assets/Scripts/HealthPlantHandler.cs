using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlantHandler : MonoBehaviour
{
    private GameObject player;
    private float playerHealth;
    public GameObject fruit;
    public float resetFruitTime = 5f;
    private Vector3 fruitScale0 = new Vector3(0f, 0f, 1f);
    private Vector3 fruitScale1 = new Vector3(1f, 1f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerHandler>().health;
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && playerHealth < 100f)
    {
        fruit.transform.localScale = fruitScale0;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<PlayerHandler>().health = 100f;
        Invoke("ResetFruit", resetFruitTime);
    }
    }

    private void ResetFruit() {
        fruit.transform.localScale = fruitScale1;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        
    }
}
