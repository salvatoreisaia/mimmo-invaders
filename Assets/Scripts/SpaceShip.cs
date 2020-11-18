using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {
    public float speed = 30f;
    public GameObject theBullet;
    public int maxBullet=4;
    public GameObject GameManager;
    public float accelerometerVelocity=5f;
    public Sprite explodedShipImage;
    private void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;

       
        //GetComponent<Rigidbody2D>().velocity = new Vector2( * accelerometerVelocity, 0) * speed;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.acceleration.x, 0));

    }

    // Update is called once per frame
    void Update () {
        if ((Input.GetButtonDown("Jump") && GameObject.FindGameObjectsWithTag("Bullet").Length < maxBullet) )
        {

            Instantiate(theBullet, transform.position, Quaternion.identity);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.bulletFire);
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && GameObject.FindGameObjectsWithTag("Bullet").Length < maxBullet) { 
            Instantiate(theBullet, transform.position, Quaternion.identity);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.bulletFire);
            }
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "Alien")
        {
            
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().playerPosition = col.transform.position;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.shipExplosion);
            col.GetComponent<SpriteRenderer>().sprite = explodedShipImage;
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PlayerDies();
            Destroy(gameObject);
            Destroy(col.gameObject, 0.5f);
        }
    }
}
