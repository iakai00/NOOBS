using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickup : MonoBehaviour 
{
    public int pointsToAdd;

    public AudioSource starSoundEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null) //  not for other than player
            return;

        ScoreManager.AddPoints(pointsToAdd);

        starSoundEffect.Play();

        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
