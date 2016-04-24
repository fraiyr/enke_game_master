using UnityEngine;
using System.Collections;

public class bigBat : MonoBehaviour {

    public Rigidbody2D projectile;
    public GameObject bat;

    public int bigBatHealth = 2;

    // Use this for initialization
    void Start () {
        Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D()
    {
        
        projectile = GameObject.Find("Projectile").GetComponent<Rigidbody2D>();
        Debug.Log(bigBatHealth);

        if (projectile)
        {
            bigBatHealth--;
            Debug.Log(bigBatHealth);
            if (bigBatHealth < 2)
            {
                DestroyObject(bat);
                Debug.Log(bigBatHealth);
                Debug.Log("Poof!");
            }
        }

        
    }
}
