using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lallo : MonoBehaviour
{
    // Base firing wait time
    public float baseFireWaitTime = 3.0f;
    // Minimum time to wait before firing
    public float minFireRateTime = 2.0f;
    private List<Vector3> bulletPosition=new List<Vector3>();
    private Vector3 currentPosition;
    // Maximum time to wait before firing
    public float maxFireRateTime = 5.0f;
    // Reference to bullet GameObject
    public GameObject alienBullet;
    public GameObject objectToBrake;
    public float lifePercent=1f;
    public Sprite explodedAlienImage;
    // Reference to animation
    private void Start()
    {
        lifePercent = 1f;
        
    }

    void FixedUpdate()
    {
        if (false)
        {
            GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,0.5f);
        }

        //shoot bullet and get position in wich instantiate brokenobject
        if (Time.timeSinceLevelLoad > baseFireWaitTime)
        {

            baseFireWaitTime = baseFireWaitTime +
                Random.Range(minFireRateTime, maxFireRateTime);
            bulletPosition.Add(GetComponent<Transform>().position);
            if (bulletPosition.Count > 2) {
                Instantiate(objectToBrake,
                    bulletPosition[Random.Range(0, bulletPosition.Count - 1)],
                    Quaternion.identity);

            }


            Instantiate(alienBullet, transform.position, Quaternion.identity);

        }

    }
}
