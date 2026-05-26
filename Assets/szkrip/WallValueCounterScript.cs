using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WallValueCounterScript : MonoBehaviour
{
    [SerializeField] Material GoodMat;
    [SerializeField] Material BadMat;

    GameObject lWall;
    GameObject rWall;
   

    [SerializeField] int lNum; // L
    [SerializeField] int rNum;

    WallScript r;
    WallScript l;

    void Awake()
    {
        lWall = gameObject.transform.GetChild(0).gameObject;
        rWall = gameObject.transform.GetChild(1).gameObject;

        r = rWall.GetComponent<WallScript>();
        l = lWall.GetComponent<WallScript>();  //még nem létezik ilyen script
        Sorsolas();
    }

    void Sorsolas()
    {
        lNum = UnityEngine.Random.Range(0, 100);
        rNum = UnityEngine.Random.Range(0, 100);
        bool sideRand = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));

        if(sideRand) lNum *= -1;
        else rNum *= -1;

        r.number = rNum;
        l.number = lNum;
    }


}
