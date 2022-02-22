/////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 02/21/2022
//Purpose: Script to control when the 
//spike ball destorys itself as well as 
//it's behaviors
//Edited by: 
//Edit Date:
////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnlargement : MonoBehaviour
{
    //timer
    float spikeEnd;

    // Start is called before the first frame update
    void Start()
    {
        spikeEnd = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease the spike timer
        spikeEnd -= Time.deltaTime;

        //check to see if the spike timer has hit zero
        if(spikeEnd <= 0.0f)
        {
            //delete this item
            Destroy(gameObject);
        }
    }
}
