using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour {
    private Rigidbody2D rigidBody;
    public float speed = 30;
    public Sprite explodedShipImage;
    GameObject GameManager;
    

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.down * speed;
        GameManager = GameObject.Find("GameManager");

    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag== "Wall")
        {
            Destroy(gameObject);

        }
        if (col.tag == "Player")
        {
            GameManager.GetComponent<GameManager>().playerPosition= col.transform.position;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.shipExplosion);
                col.GetComponent<SpriteRenderer>().sprite=explodedShipImage;
            GameManager.GetComponent<GameManager>().PlayerDies();
            Destroy(gameObject);
            Destroy(col.gameObject,0.5f);
            
            

        }
       
        if (col.tag == "Shield")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);

        }
         
    }
    void OnBecomeInvisible()
        {
            Destroy(gameObject);
        }

    
    


}
