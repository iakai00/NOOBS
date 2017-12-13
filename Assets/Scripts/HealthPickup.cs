using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour 
{
    public int HealthToGive;

    public AudioSource Pickupsound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null)
            return;
        
        Healthmanager.Hurtplayer(-HealthToGive);

        //Pickupsound.Play();

        Destroy(gameObject);
    }

}
