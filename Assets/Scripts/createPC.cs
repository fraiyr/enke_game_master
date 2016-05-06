using UnityEngine;
using System.Collections;

public class createPC : MonoBehaviour {

    public static Rigidbody2D pcObj;
    public static BoxCollider2D sceneTrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void clonePC(float xLoc)
    {
        pcObj = GameObject.Find("PC_0").GetComponent<Rigidbody2D>();
        sceneTrigger = GameObject.Find("Trigger").GetComponent<BoxCollider2D>();
        Rigidbody2D pcClone;

        Vector3 position = new Vector3((xLoc), (sceneTrigger.transform.position.y - .3f), 0);
        pcClone = (Rigidbody2D)Instantiate(pcObj, position, pcObj.transform.rotation);
    }
}
