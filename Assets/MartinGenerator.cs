using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartinGenerator : MonoBehaviour
{

    public Transform generatorPosition;
    public GameObject tobia;
    public float tobiaIntervalMin = 5f;
    public float tobiaIntervalMax = 15f;
    private float tobiaInterval;
    private float timeToGenerateTobia;
    // Use this for initialization
    private void Start()
    {
        tobiaInterval = Random.Range(tobiaIntervalMin, tobiaIntervalMax);
        timeToGenerateTobia = Time.timeSinceLevelLoad + tobiaInterval;
    }
    void GenerateTobia()
    {

        Instantiate(tobia, generatorPosition.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToGenerateTobia)
        {
            GenerateTobia();
            tobiaInterval = Random.Range(tobiaIntervalMin, tobiaIntervalMax);
            timeToGenerateTobia = Time.timeSinceLevelLoad + tobiaInterval;

        }



    }


}
