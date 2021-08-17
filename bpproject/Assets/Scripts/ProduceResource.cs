using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProduceResource : MonoBehaviour
{
    public Text produceEXP;
    public Text producePower;
    public Text produceLand;
    public Text produceWater;
    public Text produceWind;
    public Text produceFire;
    public float timer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ResourceUP();
            timer = 1.0f;
        }
    }

    public void ResourceUP()
    {
        produceEXP.text = (int.Parse(produceEXP.text) + 1).ToString();
        producePower.text = (int.Parse(producePower.text) + 1).ToString();
        produceLand.text = (int.Parse(produceLand.text) + 1).ToString();
        produceWater.text = (int.Parse(produceWater.text) + 1).ToString();
        produceWind.text = (int.Parse(produceWind.text) + 1).ToString();
        produceFire.text = (int.Parse(produceFire.text) + 1).ToString();
    }
}
