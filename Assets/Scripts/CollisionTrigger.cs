using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour {

    private BoxCollider2D playerCollider;

    [SerializeField]
    private BoxCollider2D platformCollider;

    [SerializeField]
    private BoxCollider2D platformTrigger;

	// Use this for initialization
	void Start () {

        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>(); //creating referene to the players' box collider and stores here
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true); //ignore collision between two boxe collidors
		
	}

    void OnTriggerEnter2D(Collider2D other)  // if player enter this trigger box he avoids it
    {
        if (other.gameObject.name == "Player")   
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }

    void OnTriggerExit2D(Collider2D other)  // to make the player land on inside the collider, afterwards
    {
        if (other.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
        }
        
    }
}
