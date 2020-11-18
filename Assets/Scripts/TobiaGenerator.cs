using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobiaGenerator : MonoBehaviour {

	public Transform generatorPosition;
    public GameObject tobia;
    public GameObject[] hosts;
    public GameObject linda;
    private int hostIndex=0;
    public float tobiaIntervalMin = 10f;
    public float tobiaIntervalMax = 30f;
    private float tobiaInterval;
    private float timeToGenerateTobia;
    // Use this for initialization
    private void Start()
    {
        tobiaInterval= Random.Range(tobiaIntervalMin,tobiaIntervalMax);
        timeToGenerateTobia = Time.timeSinceLevelLoad + tobiaInterval;
    }
    void GenerateTobia()
    {
        
                Instantiate(hosts[hostIndex], generatorPosition.position, Quaternion.identity);
            
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.timeSinceLevelLoad >= timeToGenerateTobia)
        {
            GenerateTobia();
            tobiaInterval = Random.Range(tobiaIntervalMin, tobiaIntervalMax);
            timeToGenerateTobia = Time.timeSinceLevelLoad + tobiaInterval;
            if (hostIndex>hosts.Length-2)
            {
                hostIndex = 0;
            }else
            {
                hostIndex++;
            }
            
        }



    }
    

}
