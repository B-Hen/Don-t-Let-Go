////////////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 02/20/2022
//Purpose: Spawner to spawn different objects
//into the game
//Edited by:
//Edit Date:
////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawItems : MonoBehaviour
{
    //gameobjects to create
    [SerializeField]
    GameObject ball, bomb;

    //touch Manger
    GameObject touchManger;

    //private floats
    float minX = -1.90f;
    float minY = -4.46f;
    float maxX = 1.90f;
    float maxY = 3.76f;

    //private timers
    float ballTimer;
    float bombTimer;

    // Start is called before the first frame update
    void Start()
    {
        ballTimer = 0.5f; //Change this time later
        bombTimer = 1.0f;

        touchManger = GameObject.Find("TouchManger");
    }

    // Update is called once per frame
    void Update()
    {
        //count down ball timer
        ballTimer -= Time.deltaTime;

        //check to see if the ball timer has rached zero
        if(ballTimer <= 0.0f)
        {
            //create a new instance of the ball object
            SpawnItem(ball);

            //reset timer
            ballTimer = 0.5f;
        }

        //count down the bomb timer
        bombTimer -= Time.deltaTime;

        //check to see if the bomb timer has reached zero
        if(bombTimer <= 0.0f)
        {
            //create a new instance of the bomb object
            SpawnItem(bomb);

            //reset the timer
            bombTimer = 1.0f;
        }
    }

    /// <summary>
    /// Method to spawn a item object everytime that item timer hits zero
    /// </summary>
    private void SpawnItem(GameObject item)
    {
        float xPosition = Random.Range(minX, maxX);
        float yPosition = Random.Range(minY, maxY);

        //make it so items can spawn on or almost on top of the player current touch position
        while((xPosition > touchManger.gameObject.transform.position.x - 0.5f && xPosition < touchManger.gameObject.transform.position.x + 0.5f) ||
            (yPosition > touchManger.gameObject.transform.position.x - 0.5f && yPosition < touchManger.gameObject.transform.position.x + 0.5f))
        {
            xPosition = Random.Range(minX, maxX);
            yPosition = Random.Range(minY, maxY);
        }

        //create the gameobject
        Instantiate(item, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
    }


}
