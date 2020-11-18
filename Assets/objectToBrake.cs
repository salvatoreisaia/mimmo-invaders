using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectToBrake : MonoBehaviour
    
{
    
    public GameObject pieceOfGlass;
    public Sprite[] piecesOfGlassSprites;
    private List<GameObject> piecesOfGlass=new List<GameObject>();
    public float explForce = 100f;
    public float Power;
    public float Radius;

    public static void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var dir = (body.transform.position - expPosition);
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }

        body.AddForce(dir.normalized * expForce * calc);
    }
    private void Start()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Alien")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.brokenCrystals);
            int listL = piecesOfGlassSprites.Length;
            for (int i=0; i < listL; i++)
            {
                float glassW = GetComponent<SpriteRenderer>().bounds.size.x;
                float glassH= GetComponent<SpriteRenderer>().bounds.size.y;
                float randomX = Random.Range(-glassW, glassW);
                float randomY= Random.Range(-glassH, glassH);
                Vector3 piecePosition = new Vector3(transform.position.x+randomX, transform.position.y+randomY, transform.position.z);

                piecesOfGlass.Add(Instantiate(pieceOfGlass, piecePosition, Quaternion.identity));
                piecesOfGlass[i].GetComponent<SpriteRenderer>().sprite=piecesOfGlassSprites[i];
                AddExplosionForce(piecesOfGlass[i].GetComponent<Rigidbody2D>(),
                    5000f,
                    transform.position,1000f                    
                    );
                
            }
            

            Destroy(gameObject,1f);
            GetComponent<SpriteRenderer>().enabled = false;
            

        }
        
    }
}
