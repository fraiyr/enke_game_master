using UnityEngine;
using System.Collections;

public class bigBat : MonoBehaviour {

    public Rigidbody2D projectile;
    public GameObject bat;

    //Create bat health total
    public int bigBatHealth = 2;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D()
    {
        //Create projectile variable
        projectile = GameObject.Find("Projectile").GetComponent<Rigidbody2D>();

        //Check for projectile collision
        if (projectile)
        {
            //Decrememnt health
            bigBatHealth--;
            //Kill bat when health is less than 1
            if (bigBatHealth < 1)
            {
                DestroyObject(bat);
            }
        }

        
    }
}
