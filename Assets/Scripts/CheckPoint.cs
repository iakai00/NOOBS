using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public LevelManager levelManager;

    // Use this for initialization
    void Start () 
    {
        levelManager = FindObjectOfType<LevelManager>(); 
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other) // if the collider got trigger by player not other
    {
        if (other.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject; // for multiple checkpoints from the prefab and after 
            //the player passes through the collider spawn on the same checkpoint
            Debug.Log("Activated Checkpoint" + transform.position);// to notify which checkpoint is triggered
        }
    }
}
