/////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 02/21/2022
//Purpose: Script to control when the 
//bomb item explodes and it's behaviors
//Edited by:
//Edit Date:
/////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    //timer
    float explosionTimer;

    // Start is called before the first frame update
    void Start()
    {
        explosionTimer = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease the explosion timer
        explosionTimer -= Time.deltaTime;

        //check to see if the explosion timer has hit zero
        if(explosionTimer <= 0.0f)
        {
            //delete this item
            Destroy(gameObject);
        }
    }
}
