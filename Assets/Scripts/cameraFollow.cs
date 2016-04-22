using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

    public GameObject Hero;

    //update is called once per frame
    void Update()
    {
        if (Hero.transform.position.x > -.32f)
        {
            transform.position = new Vector3(Hero.transform.position.x, -0.2f, 0f);
        }
    }
}
