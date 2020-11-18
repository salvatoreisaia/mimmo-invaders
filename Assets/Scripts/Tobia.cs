using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tobia : MonoBehaviour
{

    public float speed = 30;
    


    public Rigidbody2D rigidBody;
    private float baseFireWaitTime;
    
    public GameObject CannoloSiciliano;








    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();

        // Set the starting direction and speed
        rigidBody.velocity = new Vector2(1, 0) * -speed;

        // Play Sounds
        StartCoroutine(PlayTobiaSound());
        baseFireWaitTime = Random.Range(1f, 4f)+ Time.timeSinceLevelLoad;

    }

    // Play sound
    private bool initialSoundIsPlayed;
    private float waitBetweenSounds;

    public IEnumerator PlayTobiaSound()
    {
        while (true)
        {

            if (initialSoundIsPlayed == true)
            {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.tobiaLoop);
                waitBetweenSounds = SoundManager.Instance.tobiaLoop.length;
            }
            else 
            {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.tobiaInitial);
                waitBetweenSounds = SoundManager.Instance.tobiaInitial.length;
                initialSoundIsPlayed = true;
                

            }

            yield return new WaitForSeconds(waitBetweenSounds);



        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Switch direction on collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "LeftWall")
        {
            
        }
        if (col.gameObject.name == "RightWall")
        {
            
        }




    }
    private void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > baseFireWaitTime)
        {

            baseFireWaitTime = baseFireWaitTime +
                Random.Range(3f, 5f);

            Instantiate(CannoloSiciliano, transform.position, Quaternion.identity);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.tobiashoot);

        }
    }




}