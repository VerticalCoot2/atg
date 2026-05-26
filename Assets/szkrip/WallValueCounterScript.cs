using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

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
        lNum = Random.Range(0, 100);
        rNum = Random.Range(0, 100);
        bool sideRand = Random.Range(1, 101)>50;

        if(sideRand) lNum *= -1;
        else rNum *= -1;

        r.number = rNum;
        l.number = lNum;

        string rStr = ((!sideRand) ? "-" : "+" )+ $"{Mathf.Abs(rNum)}";
        string lStr = ((!sideRand) ? "+" : "-" )+ $"{Mathf.Abs(lNum)}";

        lWall.transform.GetChild(0).GetComponent<TMP_Text>().text = lStr;
        rWall.transform.GetChild(0).GetComponent<TMP_Text>().text = rStr;

        if (rNum > lNum)
        {
            rWall.GetComponent<Renderer>().material = GoodMat;
            lWall.GetComponent<Renderer>().material = BadMat;
        }
        else if (rNum < lNum)
        {
            lWall.GetComponent<Renderer>().material = GoodMat;
            rWall.GetComponent<Renderer>().material = BadMat;
        }
        else
        {
            lWall.GetComponent<Renderer>().material = GoodMat;
            rWall.GetComponent<Renderer>().material = GoodMat;
        }
    }


}
