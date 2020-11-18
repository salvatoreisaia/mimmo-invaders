using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBarManager : MonoBehaviour
{
    public Image bar;
    public float filling=1f;
    // Start is called before the first frame update
    void Start()
    {
        FillLife();
    }
    void FillLife()
    {
        bar.fillAmount = filling;
    }
    // Update is called once per frame
    void Update()
    {
        FillLife();
    }
}
