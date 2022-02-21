using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //check to see if this game object has collided with the user
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.color = Color.white;
    }


}
