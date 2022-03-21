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

public class SpikeBehavior : MonoBehaviour
{
    //floats
    [SerializeField]
    float spikeEnd, spikeMove;
    float minX = -2.48f;
    float minY = -4.53f;
    float maxX = 2.48f;
    float maxY = 3.61f;

    //boolean to actually move the spike
    bool moveSpike;

    //ints
    [SerializeField]
    int numberofMovements;

    // Start is called before the first frame update
    void Start()
    {
        moveSpike = false;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease the spike timer
        spikeEnd -= Time.deltaTime;

        //check if the spike needs to be moved
        if(spikeEnd < spikeMove && !moveSpike)
        {
            //set move spike to true
            moveSpike = true;

            //move the spike to the new Position
            StartCoroutine(NewPosition());
        }
    }

    /// <summary>
    /// Method will pick new directions to move and them lerp the spike
    /// to those positions
    /// </summary>
    private IEnumerator NewPosition()
    {
        for (int i = 0; i < numberofMovements; i++)
        {
            float xPosition = Random.Range(minX, maxX);
            float yPosition = Random.Range(minY, maxY);

            float time = Time.deltaTime * 100.0f;
            Debug.Log(time);

            //lerp the spike to the position (smootly move the object)
            transform.position = Vector3.Lerp(transform.position, new Vector3(xPosition, yPosition, 0), time);

            yield return new WaitForSeconds(time);
        }

        Destroy(gameObject);
    }
}
