using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectTouch : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI touchingText;

    [SerializeField]
    float minX, minY, maxX, maxY;

    private int numberOfTouches;    //for debugging purposes delete later
    private Touch touch;
    private Vector3 touchPosition;

    // Start is called before the first frame update
    void Start()
    {
        //set the index of the text we are interested in see
        numberOfTouches = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if the user has touched the screen
        if(Input.touchCount > numberOfTouches)
        {
            //get the touch, index at 0
            touch = Input.GetTouch(numberOfTouches);    //return a struct of the touch 

            //if the touch has began set text to yes
            if(touch.phase == TouchPhase.Began)
            {
                touchingText.text = "Touching: Yes";
            }
            //if touch ends set though to no
            else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                touchingText.text = "Touching: No";
            }

            //change the position of this gameobject to where the touch is positioned
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            //make sure the touch stays in bounds
            if (touchPosition.x < minX) { touchPosition.x = minX; }
            else if(touchPosition.x > maxX) { touchPosition.x = maxX; }
            if(touchPosition.y < minY) { touchPosition.y = minY; }
            else if(touchPosition.y > maxY) { touchPosition.y = maxY; }

            //transform.position =  new Vector3(touchPosition.x, touchPosition.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(touchPosition.x, touchPosition.y, 0), Time.deltaTime * 1000.0f);
        }
    }
}
