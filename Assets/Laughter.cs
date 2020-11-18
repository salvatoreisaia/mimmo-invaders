using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laughter : MonoBehaviour
{
    // Start is called before the first frame update
   public Animator winning;
    bool isLaughing;
    private void Start()
    {
        isLaughing = false;
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.winning);
    }
    // Update is called once per frame
    void Update()
    {



        if (winning.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !winning.IsInTransition(0) && isLaughing==false) {
            winning.Play("Risate");
            StartCoroutine(LoopLaugh());
            isLaughing = true;
        }
    }
    public IEnumerator LoopLaugh()
    {
        while (true)
        {

            SoundManager.Instance.PlayInLoop(SoundManager.Instance.laughter);
            yield return new WaitForSeconds(SoundManager.Instance.laughter.length);


        }
    }
}
