﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;

	// Use this for initialization
	void Start () 
    {
        levelManager = FindObjectOfType<LevelManager>(); 
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerEnter2D(Collider2D other) // if the collider got trigger by player not other
    {
        if (other.name == "Player")
        {
            levelManager.RespawnPlayer();
        }
    }
}
