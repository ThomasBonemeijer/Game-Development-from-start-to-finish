using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPointHandler : MonoBehaviour
{
    // The target marker.
    Transform target;
    // Angular speed in radians per sec.
    float speed = 20f;
    bool isNutFirePoint = false;
    Transform playerPos;
    public float playerDistance;
    void Start() {
        playerPos = GameObject.Find("Player").transform;
        if (transform.parent.tag == "BeeEnemy") {
            target = GameObject.Find("Player").transform;
        } else if (transform.parent.name == "EnemyTreeTrunk") {
            target = GameObject.Find("BeeTarget").transform;
            isNutFirePoint = true;
        }
    }
    void Update()
    {
        updateFirePoint();

        if(isNutFirePoint == true) {
            SwitchPlayerTarget();
        }
    }

    void updateFirePoint() {
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }

    void SwitchPlayerTarget() {
        float distance = Vector3.Distance(playerPos.position, transform.position);
        if (distance <= 7f){
            target = GameObject.Find("Player").transform;
        } else {
            target = GameObject.Find("BeeTarget").transform;
        }
    }
}
