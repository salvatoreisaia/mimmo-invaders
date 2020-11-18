using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject SpaceShip;
    public GameObject SpawnPoint;
    public Vector3 playerPosition;
    public bool isGameOver;
    public Color tra;
    public Color solid;
    public GameObject Winning;
    public GameObject GameOver;
    public GameObject Pause;

    private void Start()
    {
        isGameOver = false;
        tra = Color.white;
        tra.a = 0.5f;
        solid = Color.white;
        immunityLenght = 1.5f;
        Screen.orientation = ScreenOrientation.LandscapeLeft;


    }
    public void PlayerDies()
       
    {
        StartCoroutine(CreatenewSpaceShip());
    }

    public IEnumerator CreatenewSpaceShip()
    {


        yield return new WaitForSeconds(seconds: 0.5f);
        //Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        // Time.timeScale = 1;
        if (GameObject.FindGameObjectsWithTag("Lifes").Length != 0 && GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            LifesManager(-1);
            
        }



    }
    public IEnumerator MakeShipSolidAfter(float time)
    {


        yield return new WaitForSeconds(seconds: time);
        if (GameObject.FindGameObjectsWithTag("Player").Length>=1) { 
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<SpriteRenderer>().color = solid;
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<BoxCollider2D>().enabled = true;
        }


    }
    private GameObject[] LifesList;
    public int numberOfLifes;
    private float[] xLifes;
    public float immunityLenght;

    

    
   
    
    private void LifesManager(int change)
    {
        LifesList = GameObject.FindGameObjectsWithTag("Lifes");
        numberOfLifes = LifesList.Length;
        xLifes = new float[LifesList.Length];

        for (int i = 0; i < LifesList.Length; i++)
        {

            xLifes[i] = LifesList[i].transform.position.x;
        }

        if (change < 0 && numberOfLifes > 1)
        {

            //identify the life on the right
            float maxX = xLifes.Max();
            int maxIndex = System.Array.IndexOf(xLifes, maxX);
            //Debug.Log(maxX);
            //take of the life on the right
            Destroy(LifesList[maxIndex]);
            Instantiate(SpaceShip, playerPosition, Quaternion.identity);
            //Disattiva box collider quando resuscita...
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<BoxCollider2D>().enabled = true;
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<SpriteRenderer>().color=tra;
            StartCoroutine(MakeShipSolidAfter(immunityLenght));
            Instantiate(SpawnPoint, playerPosition, Quaternion.identity);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.ua);



        }
        else if (numberOfLifes <= 1)
        {
            //game over
            isGameOver = true;
            Destroy(LifesList[0]);
            Destroy(GameObject.FindGameObjectsWithTag("MovementParts")[0]);
            if (GameObject.FindGameObjectsWithTag("Tobia").Length != 0)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Tobia")[0]);
            }
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.gameover);
            GameOver.SetActive(true);
        }


    }
    private void DestroyMovingParts()
    {
       
    }
    public Animator anim;
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Alien").Length == 0 && isGameOver==false)
        {
            if (GameObject.FindGameObjectsWithTag("MovementParts").Length > 0)
            {
                Destroy(GameObject.FindGameObjectsWithTag("MovementParts")[0]);
            }
            if (GameObject.FindGameObjectsWithTag("Tobia").Length != 0)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Tobia")[0]);
            }
            Winning.SetActive(true);
            }
        if (Input.GetButtonDown("Fire1"))
        {
            //Winning.SetActive(true);

        }

    }
}
