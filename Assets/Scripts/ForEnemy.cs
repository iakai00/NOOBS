using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEnemy : MonoBehaviour 
{
    private Animator myAnimator;

    [SerializeField]
    private Transform knifePos;

    [SerializeField]
    private float movementSpeed; //to make it not accessible from outside and get access from inspector from unity

    private bool facingRight;

    [SerializeField]
    private GameObject knifePrefab;



    public bool Attack { get; set; }

    public GameObject Target { get; set; }




    public void ThrowKnife(int value)
    {
        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Knife>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            tmp.GetComponent<Knife>().Initialize(Vector2.left);
        }
    }
}
