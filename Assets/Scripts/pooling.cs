using UnityEngine;
using System.Collections;

public class pooling : MonoBehaviour {

	public GameObject otherBack;
    public Rigidbody2D player;
    //public GameObject batObj;

    private int backgroundPop = 0;
    private int enemyPop = 0;
    private float playerLoc;

    void Start()
    {

    }
    
    //Trigger happens when player exits collider box
    public void OnTriggerExit2D(Collider2D col)
    {
        //Get player location
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform.position.x;

        //Find the hero object
        player = GameObject.Find("Hero").GetComponent<Rigidbody2D>();

        //Make sure the player is hitting the box, not an npc
        if (col.gameObject.tag == "Player")
        {
            //This determines which way to move the level pieces so that they don't get split up
            if (player.velocity.x > 0 && (otherBack.transform.position.x < player.transform.position.x))
            {
                //Move the level section the character isn't in and create npc's
                otherBack.transform.Translate(17.26f, 0, 0);
                backgroundPop++;
                //This ensures that enemies will only spawn the first time the players makes it to each trigger point in the level
                //For example if the player hits a trigger and goes backward past the trigger, then forward past that same trigger again;
                //The game will not populate multiple sets of enemies from that same trigger point.
                if (enemyPop < backgroundPop)
                {
                    enemyPop++;
                    //Use the rng class to to populate a random location that is based on player location to spawn an enemy.
                    createBat.cloneBat(rng.getRandNum(playerLocation.currentPlayerLoc(playerLoc), playerLocation.playerMaxLoc(playerLoc)));
                }

            }
            else if(player.velocity.x < 0 && (otherBack.transform.position.x > player.transform.position.x))
            {
                otherBack.transform.Translate(-17.26f, 0, 0);
                backgroundPop--;
            }
        }
    }

    
}
