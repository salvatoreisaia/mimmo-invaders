using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linda : MonoBehaviour
{

    public float speed = 30;



    public Rigidbody2D rigidBody;
    private float baseFireWaitTime;

    public GameObject LindaBullet;








    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();

        // Set the starting direction and speed
        rigidBody.velocity = new Vector2(1, 0) * -speed;

        // Play Sounds
        StartCoroutine(PlayTobiaSound());
        baseFireWaitTime = Random.Range(1f, 4f) + Time.timeSinceLevelLoad;

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
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.hot);
                waitBetweenSounds = SoundManager.Instance.hot.length;
            }
            else
            {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.proposta);
                waitBetweenSounds = SoundManager.Instance.proposta.length;
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

            Instantiate(LindaBullet, transform.position, Quaternion.identity);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.gallina);

        }
    }




}