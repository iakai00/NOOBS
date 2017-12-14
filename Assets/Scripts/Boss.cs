using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int BossHealth;

    public GameObject DeathEffect;

    public int PointsOnDeath;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BossHealth <= 0)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);

            ScoreManager.AddPoints(PointsOnDeath);
            Destroy(gameObject);
        }
    }

    public void GiveDamage(int DamageToGive)  // current health and give damage to enemy
    {
        BossHealth -= DamageToGive;

    }
}
