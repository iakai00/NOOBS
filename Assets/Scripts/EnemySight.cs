using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    private Animator myAnimator;

    [SerializeField]
    private ForEnemy enemy;
    private float throwTimer;
    private float throwCoolDown;
    private bool canThrow;

    private void Start(ForEnemy enemy)
    {
       this.enemy = enemy;
        throwKnife();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.Target = other.gameObject;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemy.Target = null;
        }
    }

    private void throwKnife()
    {
        throwTimer += Time.deltaTime; // always increase than the previous frame

        if (throwTimer >= throwCoolDown)
        {
            canThrow = true;
            throwTimer = 0;
        }
        if (canThrow)
        {
            canThrow = false;
            enemy.GetComponent<Animator>().SetTrigger("throw");
        }
    }

}
