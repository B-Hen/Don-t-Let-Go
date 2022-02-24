////////////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 02/20/2022
//Purpose: Spawner to spawn different objects
//into the game
//Edited by: Breanna Henriquez 
//Edit Date: 02/22/2022
//Edit Purpose: To make spawn rates expoential
////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawItems : MonoBehaviour
{
    //gameobjects to create
    [SerializeField]
    GameObject ball, bomb, spike, bee;

    //touch Manger
    GameObject touchManger;

    //private floats
    float minX = -1.90f;
    float minY = -4.46f;
    float maxX = 1.90f;
    float maxY = 3.76f;

    //private timers
    float ballTimer, ballBase;
    float bombTimer, bombBase;
    float spikeTimer, spikeBase;
    float beeTimer, beeBase;

    // Start is called before the first frame update
    void Start()
    {
        //change values until it feels right 
        ballTimer = 0.1f; 
        bombTimer = 3.0f;
        spikeTimer = 5.0f;
        beeTimer = 12.0f;

        //baseTimer numbers
        ballBase = ballTimer;
        bombBase = bombTimer;
        spikeBase = spikeTimer;
        beeBase = beeTimer;

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

            //reset timer (exponential increaase) make it so it does spawn as much will the game goes on
            ballTimer = ballBase + (Mathf.Pow(ballBase, 1/25f) / 25);

            //reset the base as well
            ballBase = ballTimer;

            //cap the timer
            if(ballTimer >= 0.8f) { ballTimer = 0.8f; ballBase = 10.8f; }
        }

        //count down the bomb timer
        bombTimer -= Time.deltaTime;

        //check to see if the bomb timer has reached zero
        if(bombTimer <= 0.0f)
        {
            //create a new instance of the bomb object
            SpawnItem(bomb);

            //reset the timer (expontential decrease)
            bombTimer = bombBase - Mathf.Pow(bombBase, -2f);

            //reset the base as well
            bombBase = bombTimer;

            //make it so that the timer can't just spawn instantly
            if(bombTimer <= 0.5f) { bombTimer = 0.5f; bombBase = 0.5f; }
        }

        //decrease the spike timer
        spikeTimer -= Time.deltaTime;

        //check to see if the spike timer has reached zerp
        if(spikeTimer <= 0.0f)
        {
            //create a new instance of the spike object 
            SpawnItem(spike);

            //reset the timer (expontential decrease)
            spikeTimer = spikeBase - Mathf.Pow(spikeBase, -4f);

            //reset the base as well
            spikeBase = spikeTimer;

            //make it so that the timer can't just spawn instantly
            if(spikeTimer <= 0.5f) { spikeTimer = 0.5f; spikeBase = 0.5f; }
        }

        //count down the bee timer
        beeTimer -= Time.deltaTime;

        //check to see if the bee timer has reached zero
        if(beeTimer <= 0.0f)
        {
            //create a new instance of the bee object
            SpawnItem(bee);

            //reset the timer (expontential decrease)
            beeTimer = beeBase - Mathf.Pow(beeBase, -6f);

            //reset the base as well
            beeBase = beeTimer;

            //make it so that the timer can't just spawn instantly
            if(beeTimer <= 0.5f) { beeTimer = 0.5f; beeBase = 0.5f; }
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
