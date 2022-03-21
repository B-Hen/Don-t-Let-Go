/////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 02/21/2022
//Purpose: Script to control when the 
//bomb item explodes and it's behaviors
//Edited by: Breanna Henriquez 
//Edit Date: 3/20/2022
//Edit Purpose: To add new behavior to the bom
/////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    //timer
    [SerializeField] //make this public so you can change for different bombs later in game
    float explosionTimer, bombStartToDestruct;

    //boolean to check if bomb is about to destruct
    bool destruct;

    // Start is called before the first frame update
    void Start()
    {
        destruct = false;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease the explosion timer
        explosionTimer -= Time.deltaTime;

        //check to see if the timer is past the safety zone
        if(explosionTimer < bombStartToDestruct && !destruct)
        {
            //make the bomb grow in size and change color
            transform.localScale *= 2.0f;

            //change the color of the object // in future replace with new sprite
            this.GetComponent<SpriteRenderer>().color = Color.red;

            //set destruct to true
            destruct = true;

            //rest the timer 
            explosionTimer = 0.5f;
        }

        //check to see if the explosion timer has hit zero
        if(explosionTimer <= 0.0f)
        {
            //delete this item
            Destroy(gameObject);

            //also add a particle later
        }
    }
}
