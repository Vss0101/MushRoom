using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloControl : MonoBehaviour
{
    public bool run;
    private CanvasGroup moonCanvasGroup;
    private float flashSpeed = 1.0f;//光晕闪动速度
    private bool isOn = true;
    private float maxAlpha = 0.6f;//显示的最高alpha值
    private float minAlpha = 0.05f;//显示的最低alpha值
    // Start is called before the first frame update
    void Start()
    {
        moonCanvasGroup = GetComponent<CanvasGroup>();
       
    }

    void Stop()
    {
        moonCanvasGroup.alpha = 1;
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(run == true)
        {
            Invoke("Stop", 2);
            if (moonCanvasGroup.alpha < maxAlpha && isOn)
            {
                moonCanvasGroup.alpha += flashSpeed * Time.deltaTime;
            }
            else
            {
                isOn = false;
                moonCanvasGroup.alpha -= flashSpeed * Time.deltaTime;
                if (moonCanvasGroup.alpha < minAlpha)
                {
                    isOn = true;
                }
            }
        }
    }
}
