using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
using System.Threading.Tasks;

public class SliderLoding : MonoBehaviour
{
    private int cur;
    public Text text;
    public Slider slider;
    public GameObject LoadingP;


	void Start () 
    {
        cur = 0;
	}
	void Update () 
    {
        //单位时间内开始刷新
        Invoke("Load",2);
	}

    //迭代刷新
    void Load(){
        if(cur>=100){
            LoadingP.SetActive(false);
            //GameMain.SetActive(true);
        }
        cur = cur + 1;
        slider.value = cur;
        //显示百分比
        text.text = cur.ToString() + "%";
    }
}
