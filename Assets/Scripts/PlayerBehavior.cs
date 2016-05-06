using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour
{
    public Rigidbody2D projectile;
    private float playerLoc;
    public static int playerHealth;
    public int maxPlayerHealth;
    public static int points;
    public GameObject player;
    public float count = 15f;

    bool direction = true;
    float maxSpeed = .9f;

    private Rigidbody2D rb;
    private Animator anim;

    // Use this for initialization
   void Start()
    {
        playerHealth = 5;
        maxPlayerHealth = 5;
        points = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        projectile = GameObject.Find("Projectile").GetComponent<Rigidbody2D>();
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform.position.x;

        //Use the rng class to to populate a random location to spawn an enemy based on player location
        createBat.cloneBat(rng.getRandNum(playerLocation.currentPlayerLoc(playerLoc), playerLocation.playerMaxLoc(playerLoc)));
        createPC.clonePC(rng.getRandNum(playerLocation.currentPlayerLoc(playerLoc), playerLocation.playerMaxLoc(playerLoc)));
        createCoffee.cloneCoffee(rng.getRandNum(playerLocation.currentPlayerLoc(playerLoc), playerLocation.playerMaxLoc(playerLoc * .1f)));
        createCoffee.cloneCoffee(rng.getRandNum(playerLocation.currentPlayerLoc(playerLoc * .6f), playerLocation.playerMaxLoc(playerLoc)));
    }

    // Update is called once per frame
    void Update()
    {
        count--;
        if (Input.GetKeyDown("space") && count <= 0.0f)
        {
            createProjectile();
            count = 15f;
            //anim.Play("PlayerThrow");
        }
        if (points < (int)rb.position.x)
        {
            points = (int)rb.position.x;
        }
    }

    //framerate independent update
    void FixedUpdate()
    {

        Movement();
        AnimatePlayer();

    }

    void createProjectile()
    {
        Rigidbody2D clone;
        Vector3 position = new Vector3(rb.position.x, rb.position.y, 0);

        if (!direction)
            position.x = position.x - 0.12f;

        clone = (Rigidbody2D)Instantiate(projectile, position, transform.rotation);
        clone.velocity = transform.TransformDirection(new Vector2(1.5f, 0));
        Destroy(clone.gameObject, 2.0f);
    }

    void Movement()
    {
        //moves you left and right with A and D
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(3 * h, rb.velocity.y);

        if (rb.velocity.y == 0)
        {
            if (Input.GetKey("w"))
            {
                rb.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }

        //limits positive player speed
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        //limits negative player speed
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }

    void AnimatePlayer()
    {

        if (Mathf.Abs(rb.velocity.x) < 0.1 && Mathf.Abs(rb.velocity.y) == 0)
        {
            anim.Play("PlayerIdle");
        }

        if (Mathf.Abs(rb.velocity.x) > 0.5 && Mathf.Abs(rb.velocity.y) == 0)
        {
            anim.Play("PlayerWalkCycle");
        }

        if (Mathf.Abs(rb.velocity.y) > .01f)
        {
            anim.Play("PlayerJump");
        }

        if (rb.velocity.x < 0)
        {

            rb.transform.localRotation = Quaternion.Euler(0, 180, 0);
            direction = true;
        }
        else if (rb.velocity.x > 0)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction = false;
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && playerHealth > 0)
        {
            playerHealth--;
        }
        else if (col.gameObject.tag == "EnemyProjectile" && playerHealth > 0)
        {
            Destroy(col.gameObject);
            playerHealth--;
        }
        else if (col.gameObject.tag == "Coffee")
        {
            DestroyObject(col.gameObject);
            if (playerHealth < maxPlayerHealth)
            {
                playerHealth++;
                pointsInc(1);
            }
        }

        if (playerHealth <= 0)
        {
            DestroyObject(player);
        }

        rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
    }
 
    public static int GetHealth()
    {
        return playerHealth;
    }
    
    public static int GetPoints()
    {
        return points;
    }

    public static void pointsInc(int num)
    {
        points += num;
    }
}
