using UnityEngine;
using System.Collections;
using System;

public class BatBehavior : MonoBehaviour {

    public Rigidbody2D bat2d;
    public Animator anim;
    public Rigidbody2D player1;
    public Vector2 flyright;
    public Vector2 flyleft;
    public Vector2 flyup;
    float height;
    float leftright;
    float maxspeed;
    float count;
    float batshootspeed;
    float distanceaboveplayer;
    bool direction;
    public Rigidbody2D projectile;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        bat2d = GetComponent<Rigidbody2D>();
        player1 = GameObject.Find("Hero").GetComponent<Rigidbody2D>();
        flyright = new Vector2(8, 0);
        flyleft = new Vector2(-8, 0);
        flyup = new Vector2(0, 3);
        height = player1.position.y;
        leftright = player1.position.x;
        maxspeed = 5;
        batshootspeed = 2;
        distanceaboveplayer = .4f;
        projectile = GameObject.Find("Projectile").GetComponent<Rigidbody2D>();
    }

	
	// Update is called once per frame
	void Update () {
        if (bat2d.position.x < player1.position.x - .4)
        {
            bat2d.AddForce(flyright);
        }

        else if (bat2d.position.x > player1.position.x + .4)
        {
            bat2d.AddForce(flyleft);
        }

        if (bat2d.velocity.x > maxspeed)
            bat2d.velocity = new Vector2(maxspeed, bat2d.velocity.y);

        if (bat2d.velocity.x < -maxspeed)
            bat2d.velocity = new Vector2(-maxspeed, bat2d.velocity.y);


        if (bat2d.position.y < player1.position.y + distanceaboveplayer)
        {
            bat2d.velocity = new Vector2(bat2d.velocity.x, 2);
        }

        if (bat2d.velocity.x >= 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            direction = true;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction = false;
        }

        count -= Time.deltaTime;
        if (count <= 0)
        {
            Rigidbody2D clone;
            count = 2;
            Vector3 position = new Vector3(bat2d.position.x, bat2d.position.y - .2f, 0);

            clone = (Rigidbody2D)Instantiate(projectile, position, transform.rotation);
            clone.velocity = (player1.transform.position - transform.position).normalized * batshootspeed;
            //clone.velocity = transform.TransformDirection(new Vector2(12, 0));

            Destroy(clone.gameObject, 1);
        }

    }
}