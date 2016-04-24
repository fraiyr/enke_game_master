using UnityEngine;
using System.Collections;

public class pooling : MonoBehaviour {

	public GameObject otherBack;
    public GameObject bat0;
    public GameObject bat1;
    public Rigidbody2D player;
    public Rigidbody2D batObj;
    public BoxCollider2D sceneTrigger;
    

    

    public void OnTriggerExit2D(Collider2D col)
    {
        player = GameObject.Find("Hero").GetComponent<Rigidbody2D>();

        if (col.gameObject.tag == "Player")
        {
            if (player.velocity.x > 0 && (otherBack.transform.position.x < player.transform.position.x))
            {
                Debug.Log("Character entered trigger");

                System.Random random = new System.Random();
                int spawnBats = random.Next(0, 2);

                /*if (spawnBats == 0)
                {
                    createBat(14.266f);
                }

                else if (spawnBats == 1)
                {
                    createBat(19.266f);
                }*/

               
                    //createBat(14.266f);
                    //createBat(19.266f);
                



                otherBack.transform.Translate(17.266f, 0, 0);
                createBat(8.266f, .19f);

            }
            else if(player.velocity.x < 0 && (otherBack.transform.position.x > player.transform.position.x))
            {
                Debug.Log("Character entered trigger");

                otherBack.transform.Translate(-17.266f, 0, 0);
            }
        }
    }

    void createBat(float xLoc, float yLoc)
    {
        sceneTrigger = GameObject.Find("Trigger").GetComponent<BoxCollider2D>();
        Rigidbody2D batClone;
        Vector3 position = new Vector3((sceneTrigger.transform.position.x + xLoc), (sceneTrigger.transform.position.y + yLoc), 0);

        batClone = (Rigidbody2D)Instantiate(batObj, position, transform.rotation);
        batClone.velocity = transform.TransformDirection(new Vector2(1.5f, 0));

    }
}
