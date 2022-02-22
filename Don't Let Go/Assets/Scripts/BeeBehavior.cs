/////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 02/21/2022
//Purpose: Script to control when the 
//bee ends itself and it's behaviors
//Edited by:
//Edit Date:
////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehavior : MonoBehaviour
{
    float beeTimer;

    // Start is called before the first frame update
    void Start()
    {
        beeTimer = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease the beeTimer
        beeTimer -= Time.deltaTime;

        //check to see if the bee timer has hit zero
        if(beeTimer <= 0.0f)
        {
            //delete this item
            Destroy(gameObject);
        }
    }
}
