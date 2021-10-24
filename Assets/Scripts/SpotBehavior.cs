using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotBehavior : MonoBehaviour
{
    public bool isPair;
    public int rotation;
    public int group;
    public bool isForOrder;
    public bool isTaken = false;
    public DrinkSpot drinkSpot = null;

    void Start()
    {
        if (isForOrder == true)
            drinkSpot = gameObject.GetComponentInChildren<DrinkSpot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
