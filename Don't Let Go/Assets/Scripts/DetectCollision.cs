/////////////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 02/20/2022
//Purpose: To set up collision detect between
//the player's touch and the item
//Edited by:
//Edit Date:
/////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{
    //gameobject
    private GameObject SceneMngr;

    // Start is called before the first frame update
    void Start()
    {
        SceneMngr = GameObject.Find("SceneManger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //check to see if this game object has collided with the user
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player hits a ball add to there total time left
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Ball")
        {
            Debug.Log("Collision");
            Destroy(gameObject);
            SceneMngr.GetComponent<SceneMngr>().timer += 1.0f;
        }
        //if the player hits the bomb game over
        if(collision.gameObject.tag == "Player" && gameObject.tag == "Bomb")
        {
            SceneManager.LoadScene(1);
        }
    }
}
