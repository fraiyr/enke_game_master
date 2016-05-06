using UnityEngine;
using System.Collections;


public class cameraFollow : MonoBehaviour {

    public static int difficulty = 0;
    public GameObject Hero;
    public string message;
    Rect textArea = new Rect(Screen.width / 2 -400, Screen.height / 8f, 150, 75);
    int health = 5;
    int points;

    //update is called once per frame
    void Update()
    {
        if (Hero.transform.position.x > -2f)
        {
            transform.position = new Vector3((Hero.transform.position.x + 1f), -0.2f, 0f);
        }
        
        health = PlayerBehavior.GetHealth();
        points = PlayerBehavior.GetPoints();
        message = "Health:  " + health + "\n" + "Points: " + points;// + "\n" + "Difficulty: " + difficulty;
    }

    void OnGUI()
    {
        GUI.skin.box.fontSize = 25;
        GUI.backgroundColor = Color.black;
        GUI.contentColor = Color.green;
        //GUI.Label(textArea, message);
        GUI.Box(textArea, message);
        
    }

    public static void difficultInc(int num)
    {
        difficulty += num;
    }

    public static int getDifficult()
    {
        return difficulty;
    }
}
