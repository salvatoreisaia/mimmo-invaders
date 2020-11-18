using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {
    public float speed = 30;
    private Rigidbody2D rigidBody;
    public Sprite explodedAlienImage;
    
    

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * speed;


		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(col.tag == "Tobia")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            IncreaseTextUIScore(100);
            col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            col.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject);
            Destroy(col.gameObject, 0.5f);

        }
        if (col.tag == "Alien" && col.name!="Lallo")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            IncreaseTextUIScore(10);
            col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            col.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject);
            Destroy(col.gameObject, 0.5f);
            

        }
        if (col.name == "Lallo")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            IncreaseTextUIScore(10);
            col.GetComponent<Lallo>().lifePercent = col.GetComponent<Lallo>().lifePercent - 0.1f;


            Destroy(gameObject);
            


        }
        if (col.tag == "AlienBullet")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            IncreaseTextUIScore(5);
            col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            col.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject);
            Destroy(col.gameObject, 0.5f);

        }
        if (col.tag=="Shield")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);

        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void IncreaseTextUIScore(int points)
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();
        int score = int.Parse(textUIComp.text);
        score += points;
        textUIComp.text = score.ToString();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
