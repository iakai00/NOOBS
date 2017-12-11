using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthmanager : MonoBehaviour 
{
    public int maxPlayerHealth;
    public static int playerHealth; //singleton

    Text text;

    private LevelManager levelManager;

    public bool IsDead;

	// Use this for initialization
	void Start () 
    {
        text = GetComponent<Text>();

        playerHealth = maxPlayerHealth;

        levelManager = FindObjectOfType<LevelManager>();

        IsDead = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (playerHealth <= 0 && !IsDead) // check the player if he is dead or not
        {
            levelManager.RespawnPlayer();
            IsDead = true;
        }

        text.text = "" + playerHealth; // string of text to int value
	}

    public static void Hurtplayer(int damageToGive)
    {
        playerHealth -= damageToGive;
    }

    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
