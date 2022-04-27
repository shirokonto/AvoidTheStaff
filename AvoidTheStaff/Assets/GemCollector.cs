using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Variables;
using UnityEngine;

public class GemCollector : MonoBehaviour
{
    private int gemCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        gemCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void AddGem()
    {
        gemCounter += 1;
        Debug.Log("Picked Up Gems: " + gemCounter);
    }
}
