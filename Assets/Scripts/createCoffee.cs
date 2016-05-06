using UnityEngine;
using System.Collections;

public class createCoffee : MonoBehaviour
{


    public static Rigidbody2D cofObj;
    public static BoxCollider2D sceneTrigger;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to create npc's
    public static void cloneCoffee(float xLoc)
    {
        cofObj = GameObject.Find("SpinningCup2_0").GetComponent<Rigidbody2D>();
        //Look for the trigger to create npc's
        sceneTrigger = GameObject.Find("Trigger").GetComponent<BoxCollider2D>();
        Rigidbody2D cofClone;

        //create new bat objects relative to the trigger location
        Vector3 position = new Vector3((xLoc), (sceneTrigger.transform.position.y - .1f), 0);
        //sceneTrigger.transform.position.x +
        cofClone = (Rigidbody2D)Instantiate(cofObj, position, cofObj.transform.rotation);
        cofClone.velocity = cofObj.transform.TransformDirection(new Vector2(0, 0));

    }
}
