using UnityEngine;
using System.Collections;

public class playerLocation : MonoBehaviour {
	
	// Update is called once per frame
	public static int currentPlayerLoc (float player) {

        //float playerLocFloat = GameObject.FindGameObjectWithTag("Hero").transform.position.x;
        //float playerLocFloat = player;
        int playerLocInt = (Mathf.FloorToInt(player) + 1);

        return playerLocInt;
    }

    public static int playerMaxLoc(float player)
    {

        //float playerLocFloat = GameObject.FindGameObjectWithTag("Hero").transform.position.x;
        float playerLocFloat = player;
        int playerLocInt = Mathf.FloorToInt(playerLocFloat);
        int maxLoc = playerLocInt + 5;

        return maxLoc;
    }
}
