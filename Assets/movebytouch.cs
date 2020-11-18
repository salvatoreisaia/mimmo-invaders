using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebytouch : MonoBehaviour
{
    public float speed = 30;
    private float horzMove;


    // Update is called once per frame
    void Update()
    {
       if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            
            if (touchPosition.x> 0)
            {
                horzMove = 1f;
                GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;

            } else
            {
                horzMove = 1f;
                GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;

            }
            

        } 
    }
}
