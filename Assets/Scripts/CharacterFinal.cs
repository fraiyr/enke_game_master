using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This script makes the character move when the screen is pressed and handles the jump
public class CharacterFinal : MonoBehaviour
{
    //Condition for whether the player should jump.
    public bool jump = false;

    //Amount of force added when the player jumps.
    public float jumpForce = 10.0f;

    //Whether or not the player is grounded.
    public bool grounded = false;

    //The vertical speed of movement.
    public int movementSpeed = 10;

    //The animator that controls the characters animations
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //This method is called when the character collides with a collider (could be a platform).
    void OnCollisionEnter2D(Collision2D hit)
    {
        grounded = true;
        print("isground");
    }

    //The update method is called many times per second
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //If the jump button is pressed and the player is grounded and the character is running forward then the player should jump.
            if(grounded == true)
            {
                jump = true;
                grounded = false;

                //Trigger the Jump animation
                anim.SetTrigger("Jump");
            }
        }
    }

    //Since we are using physics for movement, we use the FixedUpdate method
    void FixedUpdate()
    {
        //if died
        GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //else
        //moving

        //If jump is set to true, we add a quick force impulse for the jump
        if(jump == true)
        {
            //Add a vertical force to the player
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            //Set the variable to false again to avoid adding force constantly
            jump = false;
        }
    }
}