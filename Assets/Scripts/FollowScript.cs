using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {
    public ForEnemy enemy;

    private Animator anime;

    private Player player;

    public GameObject Target { get; set; }


    private void Start()
    {
        player = GetComponent<Player>();
        anime = GetComponent<Animator>();
    }
    public float MoveSpeed;

    public float Range;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag  == "Player")
        {
            enemy.Target = other.gameObject;
            anime.SetTrigger("attack");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            enemy.Target = null;
        }
    }



}
