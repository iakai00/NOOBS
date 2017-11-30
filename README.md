# NOOBS
Game details

new games for the team noobs

## Authors
Ishup

Some codes for the jump mechanism is here take a look, try to code as less as possible and you need to explain and understand what you did....

public class JustJump : MonoBehaviour
{

private Rigidbody2D myRigidbody;
public float jumpSpeed = 5;

void Start () 
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update () 
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpSpeed);
        }
    }
}


## Authors
Ishup



## Authors
Ashraful

Code for Health is upcoming
