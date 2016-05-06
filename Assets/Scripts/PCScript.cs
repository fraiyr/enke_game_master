using UnityEngine;
using System.Collections;

public class PCScript : MonoBehaviour {

    public int pcHealth;
	public Rigidbody2D FloppyProjectile;
	public Rigidbody2D PC2d;
    public Rigidbody2D player1;
    public GameObject pc;

	float floppyShootSpeed = .1f;
	float count = 0f;

	// Use this for initialization
	void Start () {
        pcHealth = 3;
	
		PC2d = GetComponent<Rigidbody2D>();
		FloppyProjectile = GameObject.Find("FloppyProjectile").GetComponent<Rigidbody2D>();
        player1 = GameObject.Find("Hero").GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        int difficulty = cameraFollow.getDifficult();
        float difficultyf = (((float)difficulty * .1f) + 1);


        count++;
        if (count >= (250/difficultyf))
        {
            Rigidbody2D clone;
            Vector3 position = new Vector3((PC2d.position.x - .5f), PC2d.position.y, 0);
            Vector3 v1 = (player1.transform.position);
            Vector3 v2 = new Vector3(floppyShootSpeed, 0, 0);
            Vector3 multiply = Vector3.Scale(v1, v2);

            if (player1.transform.position.x < PC2d.transform.position.x)
            {
                clone = (Rigidbody2D)Instantiate(FloppyProjectile, position, transform.rotation);
                clone.velocity = -v2 * difficultyf;
                Destroy(clone.gameObject, 4.0f);

                count = 0;
            }
            if (player1.transform.position.x > PC2d.transform.position.x)
            {
                clone = (Rigidbody2D)Instantiate(FloppyProjectile, position, transform.rotation);
                clone.velocity = v2 * difficultyf;
                Destroy(clone.gameObject, 4.0f);

                count = 0;
            }
        }       

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "FriendlyProjectile")
        {
            pcHealth--;
            if (pcHealth < 1)
            {
                DestroyObject(pc);
                PlayerBehavior.pointsInc(1);
            }
        }
    }
}
