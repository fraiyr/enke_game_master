using UnityEngine;
using System.Collections;

public class playerLocation : MonoBehaviour {
	
	public static int currentPlayerLoc (float player) {
        
        int playerLocInt = (Mathf.FloorToInt(player) + 1);

        return playerLocInt;
    }

    public static int playerMaxLoc(float player)
    {
        float playerLocFloat = player;
        int playerLocInt = Mathf.FloorToInt(playerLocFloat);
        int maxLoc = playerLocInt + 5;

        return maxLoc;
    }
}
