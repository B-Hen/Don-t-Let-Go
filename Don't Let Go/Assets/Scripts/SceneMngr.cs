////////////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 02/21/2022
//Purpose: Script to manager the scene, game
//state, timer, money, etc.
//Edited by: Breanna Henriquez
//Edit Date: 02/22/2022
//Purpose for Edit: To add instructions to tap
//the screen before the game start
////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneMngr : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI TimerText;  //main game timer

    [SerializeField]
    GameObject ItemSpawner, TouchManger;

    //floats 
    public float timer;

    //private SpawItem Script
    SpawItems spawnItems;
    TouchManger touchMngr;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5.0f;
        TimerText.text = "Tap to Begin";

        touchMngr = TouchManger.GetComponent<TouchManger>();
        spawnItems = ItemSpawner.GetComponent<SpawItems>();
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if the game has started
        if (touchMngr.startGame)
        {
            //set the text 
            TimerText.text = "5.00";

            //enable the item spawn
            spawnItems.enabled = true;

            //decrease timer
            timer -= Time.deltaTime;
            TimerText.text = timer.ToString("0.##");

            //check if timer is zero or below
            if (timer <= 0.0f)
            {
                SceneManager.LoadScene(1); ; //Just for test, change to game over screen when more set up
            }
        }
    }
}
