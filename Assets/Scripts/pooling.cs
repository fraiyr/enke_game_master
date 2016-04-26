using UnityEngine;
using System.Collections;

public class pooling : MonoBehaviour {

	public GameObject otherBack;
    public Rigidbody2D player;
    public Rigidbody2D batObj;
    public BoxCollider2D sceneTrigger;

    private int backgroundPop = 0;
    private int enemyPop = 0;
    private float playerLoc = GameObject.FindGameObjectWithTag("Hero").transform.position.x;

    void Start()
    {
        
        Debug.Log("Begin start");
        createBat(rng.getRandNum(playerLocation.currentPlayerLoc(playerLoc), playerLocation.playerMaxLoc(playerLoc)));
        Debug.Log("End start");
    }
    
    //Trigger happens when player exits collider box
    public void OnTriggerExit2D(Collider2D col)
    {
        //Find the hero object
        player = GameObject.Find("Hero").GetComponent<Rigidbody2D>();

        //Make sure the player is hitting the box, not an npc
        if (col.gameObject.tag == "Player")
        {
            //This determines which way to move the level pieces so that they don't get split up
            if (player.velocity.x > 0 && (otherBack.transform.position.x < player.transform.position.x))
            {
                //Move the level section the character isn't in and create npc's
                otherBack.transform.Translate(17.266f, 0, 0);
                backgroundPop++;
                if (enemyPop < backgroundPop)
                {
                    enemyPop++;
                    createBat(rng.getRandNum(playerLocation.currentPlayerLoc(playerLoc), playerLocation.playerMaxLoc(playerLoc)));
                }

            }
            else if(player.velocity.x < 0 && (otherBack.transform.position.x > player.transform.position.x))
            {
                otherBack.transform.Translate(-17.266f, 0, 0);
                backgroundPop--;
            }
        }
    }

    //Function to create npc's
    void createBat(float xLoc)
    {
        Debug.Log("I'm a bat!");
        batObj = GameObject.Find("BatBigger").GetComponent<Rigidbody2D>();
        //Look for the trigger to create npc's
        sceneTrigger = GameObject.Find("Trigger").GetComponent<BoxCollider2D>();
        Rigidbody2D batClone;

        //create new bat objects relative to the trigger location
        Vector3 position = new Vector3((sceneTrigger.transform.position.x + xLoc), (sceneTrigger.transform.position.y + .19f), 0);

        batClone = (Rigidbody2D)Instantiate(batObj, position, transform.rotation);
        batClone.velocity = transform.TransformDirection(new Vector2(1.5f, 0));

    }
}
