using UnityEngine;
using System.Collections;

public class pooling : MonoBehaviour {

	public GameObject otherBack;
    public GameObject bat0;
    public GameObject bat1;

    

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Character entered trigger");

            System.Random random = new System.Random();
            int spawnBats = random.Next(0, 3);

            if (spawnBats == 0)
            {
                bat0.SetActive(true);
                bat1.SetActive(true);
            }

            if (spawnBats == 1)
            {
                bat0.SetActive(true);
                bat1.SetActive(true);
            }

            if (spawnBats == 2)
            {
                bat0.SetActive(true);
                bat1.SetActive(true);
            }
            
            

            otherBack.transform.Translate(17.266f, 0, 0);
        }
    }

}
