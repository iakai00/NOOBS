using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // attach rigid body 2d to the component

public class Knife : MonoBehaviour 
{
    [SerializeField]
    private float speed;

    private Rigidbody2D myRigidbody;

    private Vector2 direction;

    public GameObject enemyDeathEffect;

    public GameObject impactEffect;

    public int gamescore;

    public float rotationSpeed; // for rotating the projectile

    public int damageToGive;

	// Use this for initialization
	void Start () 
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = direction * speed;
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
            other.GetComponent<EnemyHealthmanager>().giveDamage(damageToGive);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        //ScoreManager.Addpoints(gamescore);
    }

    void OnbecameInvisible()
    {
        Destroy(gameObject);
    }

}
