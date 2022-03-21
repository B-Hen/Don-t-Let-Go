/////////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 2/21/2022
//Purpose: Manager user touches in the main
//game
//Edited by:
//Edit Date:
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchManger : MonoBehaviour
{
    //private floats
    float minX = -2.48f;
    float minY = -4.53f;
    float maxX = 2.48f;
    float maxY = 3.61f;

    public Touch touch;
    private Vector3 touchPosition;

    //bool
    public bool startGame;

    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if the user has touch the screen 
        if (Input.touchCount > 0)
        {
            //start the game
            startGame = true;

            //get the touch struct 
            touch = Input.GetTouch(0);

            //check to see if the user has stopped touching the screen
            if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended) { SceneManager.LoadScene(1); }       //temp change to game over screen later

            //set the position of the touch to screen space
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            //make sure the touch stays in bounds
            if (touchPosition.x < minX) { touchPosition.x = minX; }
            else if (touchPosition.x > maxX) { touchPosition.x = maxX; }
            if (touchPosition.y < minY) { touchPosition.y = minY; }
            else if (touchPosition.y > maxY) { touchPosition.y = maxY; }

            //movement of the touch
            //transform.position =  new Vector3(touchPosition.x, touchPosition.y, 0); //test to see if this way is better
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(touchPosition.x, touchPosition.y, 0), Time.deltaTime * 100.0f);
        }
    }
}
