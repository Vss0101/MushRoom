using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SlotRun : MonoBehaviour
{
    public Image pointASub;//小球
    public Image pointBSub;
    public Image pointCSub;
    public Image CircleCSub;
    public float speedA;//控制A球速度
    public float speedB;
    public float speedC;
    public float speedCircle_C;
    public int rewardA;//A球获得的奖励
    public int rewardB;
    public int rewardC;
    public Button run;//祈祷按钮
    public GameObject centerObject;
    public GameObject pointA;//小球父对象，控制转动角度
    public GameObject pointB;
    public GameObject pointC;
    public GameObject Circle_c;
    public GameObject pointForWater;//奖励所在位置
    public GameObject pointForFire;
    public GameObject pointForWind;
    public GameObject pointForLand;
    public GameObject smallEXP1;
    public GameObject smallEXP2;
    public GameObject bigEXP;
    public GameObject power;
    public int time;
    public int[] rewards;//奖励列表
    public GameObject resource;//弹出的奖励图标
    public GameObject[] rewardsPosition;//奖励列表对应的位置

    public int tili;//体力数据
    public Text Tilitext;//显示体力
    public Message tip;
    // 四元素显示
    public Text Windtext;
    public Text Firetext;
    public Text Landtext;
    public Text Watertext;
    // 四元素
    public int Wind;
    public int Fire;
    public int Land;
    public int Water;

    public GameObject globalLandRsData;
    public GameObject globalWaterRsData;
    public GameObject globalFireRsData;
    public GameObject globalWindRsData;
    public GameObject globalPower;


    // Start is called before the first frame update
    void Start()
    {
        //设置小球初始位置
        pointA.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        pointB.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        pointC.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        //设置奖励列表以及奖励对应图标
        rewards = new int[8] { 45, 135, 225, 315 ,0,90,180,270};
        rewardsPosition = new GameObject[8] { pointForLand,pointForWater,pointForFire,pointForWind,power,smallEXP1,bigEXP,smallEXP2 };
        //小球初始速度
        speedA = 30;
        speedB = 30;
        speedC = 30;
        speedCircle_C = 40;
        time = 3;

        //体力四元素初始化
        tili = int.Parse(globalPower.GetComponent<Text>().text); ;
        Wind = int.Parse(globalWindRsData.GetComponent<Text>().text);
        Fire = int.Parse(globalFireRsData.GetComponent<Text>().text);
        Land = int.Parse(globalLandRsData.GetComponent<Text>().text);
        Water = int.Parse(globalWaterRsData.GetComponent<Text>().text);

        Windtext.text = Wind.ToString();
        Firetext.text = Fire.ToString();
        Landtext.text = Land.ToString();
        Watertext.text = Water.ToString();

        

        run.onClick.AddListener(delegate () { OnClick(); });
    }

    //点击按钮后开始调用老虎机转动函数
    public void OnClick()
    {
        if(tili<=0){
            tip.GetMessage("没有体力啦");
            run.enabled = false;
        }
        else{
            tili = tili - 1;
            speedA = 0;
            speedB = 0;
            speedC = 0;
            Tilitext.text = tili.ToString();
            SlotGo();
            //禁用祈祷按钮，防止玩家疯狂按
            run.enabled = false;
        }
        
        
    }

    public int GetRandom()
    {
        return Random.Range(0, 7);
    }

    public void ReverseStopFlag()
    {
        speedA = Random.Range(10, 100);
        speedB = Random.Range(10, 100);
        speedC = Random.Range(10, 100);
        run.enabled = true;
    }

    public void GetRewards(int rewardA,int rewardB,int rewardC) { 
        //通过三个球的Reward是否相同来调用对应的发奖函数
        if(rewardA == rewardB && rewardC == rewardA)
        {
            GetBigReward(rewardA);
        }else if(rewardA == rewardB || rewardA == rewardC || rewardB == rewardC)
        {
            int reward = rewardA == rewardB ? rewardA :rewardC;
            GetMiddleReward(reward);
        }
        else
        {
            GetSmallReward();
        }

    }

    public void GetMiddleReward(int reward)
    {
        //调用闪烁函数
        rewardsPosition[reward].GetComponent<HaloControl>().run = true;

        WhatReward(reward,2);

        for (int i = 0; i < 5; i++)
        {
            float positionX = rewardsPosition[reward].transform.position.x;
            float positionY = rewardsPosition[reward].transform.position.y;
            GameObject go = GameObject.Instantiate(resource, new Vector3(positionX + Random.Range(-70, 70), positionY + Random.Range(-70, 70), 0), Quaternion.identity);
            go.transform.SetParent(centerObject.transform);
        }
    }

    public void GetSmallReward()
    {

    }

    public void GetBigReward(int reward)
    {
        //调用闪烁函数
        rewardsPosition[reward].GetComponent<HaloControl>().run = true;

        WhatReward(reward,5);

        //在对应奖励位置附近生成5个奖励图标，每个奖励图标自身有代码可以控制飞到某个位置自行销毁
        for (int i = 0; i < 5; i++)
        {
            float positionX= rewardsPosition[reward].transform.position.x;
            float positionY = rewardsPosition[reward].transform.position.y;
            GameObject go =GameObject.Instantiate(resource, new Vector3(positionX + Random.Range(0, 50), positionY + Random.Range(0, 50), 0), Quaternion.identity);
            go.transform.SetParent(centerObject.transform);
        }
        
    }

    public void SlotGo()
    {
        //让小球分别获得奖励
        rewardA = GetRandom();
        rewardB = GetRandom();
        rewardC = GetRandom();
        //确定小球停留位置，并设置其动画效果
        Tween t = pointC.transform.DORotate(new Vector3(0, 0, rewards[rewardA] - pointC.transform.eulerAngles.z + 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        t.OnComplete(
            () =>
            {
                //等动画播完后调用拿奖函数
                GetRewards(rewardA, rewardB, rewardC);
                //并让小球继续转动
                Invoke("ReverseStopFlag", 0.5f);
            }
        );
        pointA.transform.DORotate(new Vector3(0, 0, rewards[rewardB] - pointA.transform.eulerAngles.z + 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        pointB.transform.DORotate(new Vector3(0, 0, rewards[rewardC] - pointB.transform.eulerAngles.z + 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
    }

    // Update is called once per frame
    void Update()
    {
        //小球根据不停转动
        pointA.transform.Rotate(Vector3.forward, speedA * Time.deltaTime);
        pointB.transform.Rotate(Vector3.forward, speedB * Time.deltaTime);
        pointC.transform.Rotate(Vector3.forward, speedC * Time.deltaTime);
        Circle_c.transform.Rotate(Vector3.forward, speedCircle_C * Time.deltaTime);
    }

    //判断老虎机封装
    void WhatReward(int reward,int grade){
        //获得四元素
        switch (reward)
        {
            case 0 : Land = Land + 10*grade;Windtext.text = Wind.ToString();break;
            case 1 : Water = Water + 10*grade;Firetext.text = Fire.ToString();break;
            case 2 : Fire = Fire + 10*grade;Landtext.text = Land.ToString();break;
            case 3 : Wind = Wind + 10*grade;Watertext.text = Water.ToString();break;
            default: break;
        }
    }
}
