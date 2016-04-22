using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {


    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            Destroy(gameObject);
        }
    }
}
