////////////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 02/21/2022
//Purpose: Script to manager the scene, game
//state, timer, money, etc.
//Edited by:
//Edit Date:
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

    //floats 
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease timer
        timer -= Time.deltaTime;
        TimerText.text = timer.ToString("0.##");

        //check if timer is zero or below
        if(timer <= 0.0f)
        {
            SceneManager.LoadScene(1); ; //Just for test, change to game over screen when more set up
        }
    }
}
