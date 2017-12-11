using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour 
{
    private bool playerIn;

    public string NextScene;

	// Use this for initialization
	void Start ()
    {
        playerIn = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerIn)
        {
            Application.LoadLevel(NextScene);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerIn = false;
        }
    }
}
