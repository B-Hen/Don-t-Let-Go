//////////////////////////////////////////////
//Developer: Breanna Henriquez 
//Date: 2/21/2022
//Purpose: Button to restart game
//Edited by:
//Edit Date:
//////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Restart()
    {
        SceneManager.LoadScene(2);
    }
}
