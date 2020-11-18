using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienInv : MonoBehaviour
{

    public float speed = 10;

    public Rigidbody2D rigidBody;

    // Starting sprite
    public Sprite startingImage;

    // Alternative image used for the Alien
    public Sprite altImage;

    // Used to change the Alien image
    private SpriteRenderer spriteRenderer;

    // Wait time before switching sprites
    public float secBeforeSpriteChange = 0.5f;




    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();

        // Set the starting direction and speed
        rigidBody.velocity = new Vector2(1, 0) * speed;

        // Access the SpriteRenderer component 
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Call changeAlienSprite () to cycle the Alien sprites
        StartCoroutine(ChangeAlienSprite());

        // Defines a random fire wait time for each Alien
     
        

    }

    // Changes the direction for the Alien object
    void Turn(int direction)
    {
        
    }

    // Moves the Alien vertically down
    void MoveDown()
    {
        
    }


    // Switch direction on collision
    void OnCollisionEnter2D(Collision2D col)
    {
       


    }
    // inizialize boolean to check sound manager inizialization
    public bool soundManInizialized = false;
    public bool miSaid = false;
    // Used to change the current sprite and play sounds
    public IEnumerator ChangeAlienSprite()
    {
        while (true)
        {
            
            if (spriteRenderer.sprite == startingImage)
            {
                spriteRenderer.sprite = altImage;
                
                
                  if (soundManInizialized == true && GameObject.FindGameObjectsWithTag("Alien").Length !=0 && GameObject.FindGameObjectsWithTag("Tobia").Length == 0) {
                    SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienBuzz1);
                    
                }
            }
            else
            {
                if (soundManInizialized == true && GameObject.FindGameObjectsWithTag("Alien").Length != 0 && GameObject.FindGameObjectsWithTag("Tobia").Length == 0) {
                    SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienBuzz2);
                    
                    secBeforeSpriteChange = GameObject.FindGameObjectsWithTag("Alien")[0].GetComponent<Alien>().secBeforeSpriteChange;

                }
                spriteRenderer.sprite = startingImage;
                
                soundManInizialized = true;

            }

            
            //

            yield return new WaitForSeconds(secBeforeSpriteChange);
            

        }
    }

    // Have Aliens fire bullets at random times
    

    void OnTriggerEnter2D(Collider2D col)
    {

        
    }
    

}