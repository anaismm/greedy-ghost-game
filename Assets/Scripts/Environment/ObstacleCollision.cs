using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;

    void OnTriggerEnter(Collider other) {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false; 
        thePlayer.GetComponent<PlayerLives>().TakeDamage();
        // charModel.GetComponent<Animator>().Play("Collide");
        charModel.GetComponent<Animator>().SetTrigger("Collide");
    }

}
