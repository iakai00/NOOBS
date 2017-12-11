using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiNew : MonoBehaviour 
{
    public float speed;

    public Player player;

    private Vector2 direction;
	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<Player>();

        if (player.transform.localScale.x < 0)
            speed = -speed;
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        //GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
