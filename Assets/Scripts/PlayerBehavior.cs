using UnityEngine;
using System.Collections;

	public class PlayerBehavior : MonoBehaviour {
	public GameObject player;

    public Rigidbody2D projectile;

    float speed = 50;
    bool direction = true;
	bool grounded = true;
	float maxSpeed = 1;
	float jumpPower = 1;

	public Rigidbody2D rb;
	public Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        projectile = GameObject.Find("Projectile").GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetKeyDown("space"))
        {
            createProjectile();
        }
	}

	//framerate independent update
	void FixedUpdate() {

		Movement();
		AnimatePlayer();
        		
	}

	void Movement()
	{
		//moves you left and right with A and D
		float h = Input.GetAxis("Horizontal");
		//rb.AddForce(Vector2.right * h * speed);
		rb.velocity = new Vector2(3 * h, rb.velocity.y);

		if (rb.velocity.y == 0)
		{
		//float v = Input.GetAxis("Vertical");
		///print(v);
		//rb.velocity = new Vector2(rb.velocity.x, 50 * v);
		if (Input.GetKey("w")){
			rb.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
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

    	if (Mathf.Abs(rb.velocity.x) < 0.1){
    		anim.Play("PlayerIdle");
    	}

        if (Mathf.Abs(rb.velocity.x) > 0.5 && Mathf.Abs(rb.velocity.y) <= 1)
        {
            anim.Play("PlayerWalkCycle");
        }

        if (rb.velocity.x < 0) {
           
            rb.transform.localRotation = Quaternion.Euler(0, 180, 0);
            direction = true;
        }
        else if (rb.velocity.x > 0)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction = false;
        }
     
    	
    }

    void createProjectile()
    {
        Rigidbody2D clone;
        Vector3 position = new Vector3(rb.position.x, rb.position.y, 0);

        if (!direction)
            position.x = position.x - 0.12f;            

        clone = (Rigidbody2D)Instantiate(projectile, position, transform.rotation);
        clone.velocity = transform.TransformDirection(new Vector2(0.5f, 0));
        Destroy(clone.gameObject, 5);
    }

}
