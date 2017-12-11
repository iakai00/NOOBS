using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private Player player;

    public GameObject deathParticle;

    public GameObject respawnParticle;

    public int pointPenaltyOnDeath;

    public float respawnDelay;

    public Healthmanager healthManager; // so the player doesnt die every time his hp is 0, from healthmanager

	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<Player>();

        healthManager = FindObjectOfType<Healthmanager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation); // to create at the same point

        player.enabled = false; //disable the player after death

        player.GetComponent<Renderer>().enabled = false;

        ScoreManager.AddPoints(-pointPenaltyOnDeath); // on death penalty point

        Debug.Log("PlayerRespawn");

        yield return new WaitForSeconds(respawnDelay);

        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true; //disable the player after death

        player.GetComponent<Renderer>().enabled = true;

        healthManager.FullHealth();

        healthManager.IsDead = false; // so that it doesnt call for kill player script


        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation); // to create at the checkpoint
    }

}
