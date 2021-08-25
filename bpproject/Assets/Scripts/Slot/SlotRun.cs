//using System.Numerics;
using System.Reflection;
using System.Linq.Expressions;
using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using ForeverNine.MagicCoast;


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

    public int tili ;//体力数据
    public Text Tilitext;//显示体力
    public Slider slider;//体力条

    public Message tip;

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
        rewardsPosition = new GameObject[8] { pointForWater,pointForFire,pointForLand,pointForWind,bigEXP,smallEXP1,power,smallEXP2 };
        //小球初始速度
        speedA = 30;
        speedB = 30;
        speedC = 30;
        speedCircle_C = 40;
        time = 2;

        //体力四元素初始化
        tili = int.Parse(globalPower.GetComponent<Text>().text); ;
        Wind = int.Parse(globalWindRsData.GetComponent<Text>().text);
        Fire = int.Parse(globalFireRsData.GetComponent<Text>().text);
        Land = int.Parse(globalLandRsData.GetComponent<Text>().text);
        Water = int.Parse(globalWaterRsData.GetComponent<Text>().text);

        //体力初始化
        slider.value = tili;
        Tilitext.text = tili.ToString() + "/100";

        

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
            globalPower.GetComponent<Text>().text = tili.ToString();
            speedA = 0;
            speedB = 0;
            speedC = 0;
            SlotGo();
            updataTili();
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
            GetSmallReward(rewardA,rewardB,rewardC);
        }

    }

    public void GetMiddleReward(int reward)
    {
        //调用闪烁函数
        if(!pdTili(reward)){
            rewardsPosition[reward].GetComponent<HaloControl>().run = true;
            showRewardDh(reward,3);
        }
        WhatReward(reward,5);
    }

    public void GetSmallReward(int rewardA,int rewardB,int rewardC)
    {
        //调用闪烁函数
        if(!pdTili(rewardA)){
            rewardsPosition[rewardA].GetComponent<HaloControl>().run = true;
            showRewardDh(rewardA,3);
        }
        if(!pdTili(rewardB)){
            rewardsPosition[rewardB].GetComponent<HaloControl>().run = true;
            showRewardDh(rewardB,3);
        }
        if(!pdTili(rewardC)){
            rewardsPosition[rewardC].GetComponent<HaloControl>().run = true;
            showRewardDh(rewardC,3);
        }

        WhatReward(rewardA,1);

        WhatReward(rewardB,1);

        WhatReward(rewardC,1);
    }

    public void GetBigReward(int reward)
    {
        //调用闪烁函数
        rewardsPosition[reward].GetComponent<HaloControl>().run = true;
        showRewardDh(reward,8);
        WhatReward(reward,5);
    }

    public void SlotGo()
    {
        //让小球分别获得奖励
        rewardA = GetRandom();
        rewardB = GetRandom();
        rewardC = GetRandom();
        //确定小球停留位置，并设置其动画效果
        Tween t = pointC.transform.DORotate(new Vector3(0, 0, rewards[rewardA] - pointC.transform.eulerAngles.z - 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        t.OnComplete(
            () =>
            {
                //等动画播完后调用拿奖函数
                GetRewards(rewardA, rewardB, rewardC);
                //并让小球继续转动
                Invoke("ReverseStopFlag", 0.5f);
            }
        );
        pointA.transform.DORotate(new Vector3(0, 0, rewards[rewardB] - pointA.transform.eulerAngles.z - 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        pointB.transform.DORotate(new Vector3(0, 0, rewards[rewardC] - pointB.transform.eulerAngles.z - 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
    }

    // Update is called once per frame
    void Update()
    {
        //小球根据不停转动
        pointA.transform.Rotate(-Vector3.forward, speedA * Time.deltaTime);
        pointB.transform.Rotate(-Vector3.forward, speedB * Time.deltaTime);
        pointC.transform.Rotate(-Vector3.forward, speedC * Time.deltaTime);
        Circle_c.transform.Rotate(-Vector3.forward, speedCircle_C * Time.deltaTime);
    }

    //判断老虎机封装,grade判断奖励大小1.small;2.midlle;3.big;
    void WhatReward(int reward,int grade){
        //获得四元素
        switch (reward)
        {
            case 0 : Water = Water + 10*grade;globalWaterRsData.GetComponent<Text>().text = Water.ToString();break;
            case 1 : Fire = Fire + 10*grade;globalFireRsData.GetComponent<Text>().text = Fire.ToString();break;
            case 2 : Land = Land + 10*grade;globalLandRsData.GetComponent<Text>().text = Land.ToString();break;
            case 3 : Wind = Wind + 10*grade;globalWindRsData.GetComponent<Text>().text = Wind.ToString();break;
            case 4 : // 大经验
            case 5 : // 小经验
            case 6 : if(grade==5){
                tili = (tili + 10 > 100?100:tili+10);updataTili();break;
                }
                else{
                    break;
                }
            default: break;
        }
    }

    void updataTili(){
        Tilitext.text = tili.ToString() + "/100";
        slider.value = tili;
        globalPower.GetComponent<Text>().text = tili.ToString();
    }

    bool pdTili(int reward){
        if(reward == 6 || reward == 4){
            return true;
        }
        else{
            return false;
        }
    }

    // 使用贝塞尔曲线实现获得奖励后奖励运动轨迹
    void showRewardDh(int reward,int grade){

            // 获得奖励的位置
            float positionX = rewardsPosition[reward].transform.position.x;
            float positionY = rewardsPosition[reward].transform.position.y;

            // 实例化
            for(int i=0;i<grade;i++){

                float StartX = positionX + Random.Range(-50,50);
                float StartY = positionY + Random.Range(-50,50);

                resource.GetComponent<GetResource>().changePicture(reward);
                GameObject go = GameObject.Instantiate(resource, new Vector3(StartX, StartY, 0), new Quaternion());
            
                // 设置父对象，不然go不会显示
                go.transform.SetParent(centerObject.transform) ;
                go.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

                Vector3[] ctrlPoints = new Vector3[3];

                // 贝塞尔曲线起始位置
                ctrlPoints[0] = go.transform.position;;

                // 拐弯点
                ctrlPoints[1] = new Vector3(StartX - Random.Range(0,50), StartY + 50, 0);

                // 贝塞尔曲线终点位置，除了体力都在中间
                if(reward == 6){
                    ctrlPoints[2] = new Vector3(145, 400, 0);
                }
                else {
                    ctrlPoints[2] = new Vector3(377, 800, 0);
                }

                // 运动轨迹
                go.GetComponent<GetResource>().getIsStart(true, ctrlPoints);

            }
    }        
}
