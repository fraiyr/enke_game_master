using UnityEngine;
using System.Collections;

public class createBat : MonoBehaviour {


    public static Rigidbody2D batObj;
    public static BoxCollider2D sceneTrigger;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Function to create npc's
    public static void cloneBat(float xLoc)
    {
        Debug.Log("I'm a bat!");
        batObj = GameObject.Find("BatBigger").GetComponent<Rigidbody2D>();
        //Look for the trigger to create npc's
        sceneTrigger = GameObject.Find("Trigger").GetComponent<BoxCollider2D>();
        Rigidbody2D batClone;

        //create new bat objects relative to the trigger location
        Vector3 position = new Vector3((sceneTrigger.transform.position.x + xLoc), (sceneTrigger.transform.position.y + .1f), 0);

        batClone = (Rigidbody2D)Instantiate(batObj, position, batObj.transform.rotation);
        batClone.velocity = batObj.transform.TransformDirection(new Vector2(1.5f, 0));

    }
}
