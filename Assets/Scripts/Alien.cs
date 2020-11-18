
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien: MonoBehaviour
{

    public float speed = 10;
    public float minSpeed = 10;
    public float maxSpeed = 50;
    public int moveDown = 1;

    public Rigidbody2D rigidBody;

    // Starting sprite
    public Sprite startingImage;

    // Alternative image used for the Alien
    public Sprite altImage;

    // Used to change the Alien image
    private SpriteRenderer spriteRenderer;

    // Wait time before switching sprites
    public float secBeforeSpriteChange = 0.5f;
    private float initialSecBeforeSpriteChange;

    // Reference to bullet GameObject
    public GameObject alienBullet;

    // Minimum time to wait before firing
    public float minFireRateTime = 2.0f;

    // Maximum time to wait before firing
    public float maxFireRateTime = 5.0f;

    // Base firing wait time
    public float baseFireWaitTime = 3.0f;

    // Exploded Ship Image
    public Sprite explodedShipImage;
    private float InitialNumberOfAliens;
    private float CurrentNumberOfAliens;
    
    GameObject GameManager;


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
        baseFireWaitTime = baseFireWaitTime +
            Random.Range(minFireRateTime, maxFireRateTime);
        InitialNumberOfAliens = GameObject.FindGameObjectsWithTag("Alien").Length;
        initialSecBeforeSpriteChange = secBeforeSpriteChange;

    }

    // Changes the direction for the Alien object
    void Turn(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }

    // Moves the Alien vertically down
    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= moveDown;
        transform.position = position;
    }


    // Switch direction on collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "LeftWall")
        {
            Turn(1);
            MoveDown();
        }
        if (col.gameObject.name == "RightWall")
        {
            Turn(-1);
            MoveDown();
        }
        




    }
    // inizialize boolean to check sound manager inizialization
    public bool soundManInizialized = false;
    // Used to change the current sprite and play sounds
    public IEnumerator ChangeAlienSprite()
    {
        while (true)
        {
            
            if (spriteRenderer.sprite == startingImage)
            {
                spriteRenderer.sprite = altImage;
                speed = minSpeed + ((maxSpeed - minSpeed) - (maxSpeed - minSpeed) * (CurrentNumberOfAliens / InitialNumberOfAliens));

                // if (soundManInizialized == true) { SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienBuzz1); }
            } else if (spriteRenderer.sprite == altImage)
            {
               // if (soundManInizialized == true) {SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienBuzz2);}
                spriteRenderer.sprite = startingImage;
                soundManInizialized = true;
                secBeforeSpriteChange = initialSecBeforeSpriteChange - (0.3f-0.3f * (CurrentNumberOfAliens / InitialNumberOfAliens));
                speed = minSpeed + ((maxSpeed-minSpeed) - (maxSpeed - minSpeed) * (CurrentNumberOfAliens / InitialNumberOfAliens));


            }

            yield return new WaitForSeconds(secBeforeSpriteChange);
            


        }
    }

    // Have Aliens fire bullets at random times
    void FixedUpdate()
    {
        CurrentNumberOfAliens = GameObject.FindGameObjectsWithTag("Alien").Length;

        if (Time.timeSinceLevelLoad > baseFireWaitTime)
        {

            baseFireWaitTime = baseFireWaitTime +
                Random.Range(minFireRateTime, maxFireRateTime);

            Instantiate(alienBullet, transform.position, Quaternion.identity);

        }
        
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log(col.name);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("collision with spaceship detected");
            GameManager.GetComponent<GameManager>().playerPosition = col.transform.position;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.shipExplosion);
            col.GetComponent<SpriteRenderer>().sprite = explodedShipImage;
            
            GameManager.GetComponent<GameManager>().PlayerDies();
            Destroy(gameObject);
            Destroy(col.gameObject, 0.5f);
        }
    }*/


}