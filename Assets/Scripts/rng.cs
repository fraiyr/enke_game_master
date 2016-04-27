using UnityEngine;
//using System.Collections;
using System;

public class rng : MonoBehaviour {

    //Generate a random number based on low and high that are passed in
    public static float getRandNum(int rndLow, int rndHigh){
        System.Random rnd = new System.Random();

        float number;
        number = (rnd.Next(rndLow, rndHigh) + 2);

        return number;
    }
}
