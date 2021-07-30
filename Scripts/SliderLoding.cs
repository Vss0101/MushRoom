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
    public GameObject GameMain;


	void Start () 
    {
        cur = 0;
	}
	void Update () 
    {
        //单位时间内刷新
        Invoke("Load",2);
	}

    //迭代刷新
    void Load(){
        if(cur>100){
            //关闭进度条界面
            LoadingP.SetActive(false);
            //打开游戏主界面
            GameMain.SetActive(true);
        }
        cur = cur + 1;
        slider.value = cur;
        //显示百分比
        text.text = cur.ToString() + "%";
    }
}
