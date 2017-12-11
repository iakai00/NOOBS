using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

    private static Player instance;         // to get access the player singleton instance from outside

    public static Player Instance           
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    public Transform firePoint;

    public GameObject star;

    private float moveVelocity;


    private Animator myAnimator;

    [SerializeField]
    private Transform knifePos;

    [SerializeField]        
    private float movementSpeed; //to make it not accessible from outside and get access from inspector from unity

    [SerializeField]
    private EdgeCollider2D sword; // for the sword collider

    private bool facingRight;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;



    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private GameObject knifePrefab;

    public Rigidbody2D MyRigidbody { get; set; }

    public bool Attack { get; set; }

    public bool Slide { get; set; }

    public bool Jump { get; set; }

    public bool OnGround { get; set; }

    public GameObject jumpSound;

	// Use this for initialization
	void Start () 
    {
        facingRight = true;
        MyRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();  //referencing the animator from unity
	}

     void Update()
    {
        HandleInput();

        moveVelocity = 0f;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(star, firePoint.position, firePoint.rotation);
        }


    }

    // Update is called once per frame
    void FixedUpdate() //update runs on fps so used fixed as it runs regardless of hardware or platform
    { 
        
        float horizontal = Input.GetAxis("Horizontal"); // gives the horizontal axes details from unity

        OnGround = IsGrounded();

        HandleMovement(horizontal); // to handle the horizontal movement

        Flip(horizontal);

        HandleLayers();

    }

    private void HandleMovement(float horizontal) // so we can use it here to change the value so defined earlier
    {
        if (MyRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("land", true);
        }
        if (!Attack && !Slide && (OnGround || airControl))// &&  (KnockBackCount <= 0))
        {
            MyRigidbody.velocity = new Vector2(horizontal * movementSpeed, MyRigidbody.velocity.y);
            //moveVelocity = movementSpeed;
        }

        //else
        //{
          //  if (KnockFromRight)
               // MyRigidbody.velocity = new Vector2(-KnockBack, KnockBack);
            //if (!KnockFromRight)
             //   MyRigidbody.velocity = new Vector2(KnockBack, KnockBack);
           // KnockBackCount -= Time.deltaTime;
        //}

        //MyRigidbody.velocity = new Vector2(moveVelocity, MyRigidbody.velocity.y);

        if (Jump && MyRigidbody.velocity.y == 0)
        {
            MyRigidbody.AddForce(new Vector2(0, jumpForce));
        }

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

    }


    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetTrigger("jump");
            //jumpSound.Play();
            jumpSound.GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            myAnimator.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            myAnimator.SetTrigger("slide");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            myAnimator.SetTrigger(("throw"));
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) // to flip him if is idle condition i.e. face right is not there
        {
            facingRight = !facingRight; //e.g. 1*-1 = -1, so -1*-1=1, to flip

            Vector3 theScale = transform.localScale; // to access player local scale in unity

            theScale.x *= -1;

            transform.localScale = theScale;

        }
    }


    private bool IsGrounded()
    {
        if (MyRigidbody.velocity.y <=0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!OnGround)
        {
            myAnimator.SetLayerWeight(1,1);
        }
        else
        {
            myAnimator.SetLayerWeight(1,0);
        }
    }

    public void MeleeAttack()
    {
        Debug.Log("sword");
        sword.enabled = !sword.enabled; // to make it work when needed
    }

    public void ThrowKnife(int value) //direction to throw the knife
    {
        if (!OnGround && value == 1 || OnGround && value == 0)    // one knife per animation
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

}
