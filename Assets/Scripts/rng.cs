using UnityEngine;
//using System.Collections;
using System;

public class rng : MonoBehaviour {

    public static float getRandNum(int rndLow, int rndHigh){
        System.Random rnd = new System.Random();

        float number;
        number = rnd.Next(rndLow, rndHigh);

        return number;
    }
}
