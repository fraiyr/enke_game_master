using UnityEngine;
using System.Collections;

public class BasicMobBehavior : MonoBehaviour {
	public GameObject Enemy;

	public Rigidbody2D rb;
	public Animator anim;

	public Rigidbody2D projectile;


	int i = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		projectile = GameObject.Find("Projectile").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//framerate independent update
	void FixedUpdate() {

		
		if (i == 1)
		{
			createProjectile();			
		}

		i++;

		if (i > 50){
			i = 1;
		}
		
	}

	void Pathing(){
		


	}

	void createProjectile(){
		Rigidbody2D clone; 
		Vector3 position = new Vector3(rb.position.x - 0.06f, rb.position.y, 0);
		clone = (Rigidbody2D)Instantiate(projectile, position, transform.rotation);
        clone.velocity = new Vector2(-0.5f, 0);
        Destroy(clone.gameObject, 5);
	}
}
