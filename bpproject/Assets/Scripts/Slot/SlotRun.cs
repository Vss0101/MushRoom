using System.ComponentModel;
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
    public GameObject TiliObject;
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
    public GameObject ExpPosition;

    public Text Tilitext;//显示体力
    public Slider slider;//体力条
    public int tili;
    public bool changePower = false;

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
    public GameObject globalExp;

    public int betNum = 1; // 倍数
    public Button bet; // 倍数按钮
    public Text Bettext;

    public int exp;// 经验
    public Text expText;
    public bool changeExp = false;

    public int SlotTime = 0;// 保底转到大奖次数

    public GameObject simplePortalPurple;

    public GameObject rewardsHead1;
    public GameObject rewardsHead2;
    public GameObject rewardsHead3;
    public GameObject trail1;
    public GameObject trail2;
    public GameObject trail3;


    public GameObject bigEXPHighLight;
    public GameObject smallEXP1HightLight;
    public GameObject smallEXP2HightLight;
    public GameObject waterHightLight;
    public GameObject windHightLight;
    public GameObject fireHightLight;
    public GameObject landHightLight;
    public GameObject powerHightLight;
    public GameObject[] rewardsHighLight;


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
        rewardsHighLight = new GameObject[8] { waterHightLight, fireHightLight, landHightLight, windHightLight,bigEXPHighLight, smallEXP1HightLight, powerHightLight, smallEXP2HightLight };
        //小球初始速度
        speedA = 30;
        speedB = 30;
        speedC = 30;
        speedCircle_C = 40;
        time = 2;

        //四元素初始化
        Wind = int.Parse(globalWindRsData.GetComponent<Text>().text);
        Fire = int.Parse(globalFireRsData.GetComponent<Text>().text);
        Land = int.Parse(globalLandRsData.GetComponent<Text>().text);
        Water = int.Parse(globalWaterRsData.GetComponent<Text>().text);

        //体力初始化
        tili = int.Parse(globalPower.GetComponent<Text>().text);
        slider.value = tili;
        bet.onClick.AddListener(delegate () { BetOnClick(); });
        Tilitext.text = tili + "/100";

        exp = int.Parse(globalExp.GetComponent<Text>().text);
        expText.text = "✖" + exp;

        run.onClick.AddListener(delegate () { ClickChangeP(); });
        simplePortalPurple.GetComponent<ParticleSystem>().Stop();
    }

    public void ClickChangeP(){
        run.image.sprite = Resources.Load<Sprite>("开始按钮背景点击");
        Invoke("OnClick",0.05f);
    }

    //点击按钮后开始调用老虎机转动函数
    public void OnClick()
    {
        run.image.sprite = Resources.Load<Sprite>("开始按钮背景");
        if(tili<=0){
            tip.GetMessage("Power Not Enough");
        }
        else{
            if(tili - 1 * betNum<=0){
                betNum = 1;
                Bettext.text = betNum.ToString();
            }
            tili = tili - 1 * betNum;
            changePower = true;
            SlotTime++;
            speedA = 0;
            speedB = 0;
            speedC = 0;
            SlotGo();
            //禁用祈祷按钮，防止玩家疯狂按
            run.enabled = false;
        }
        
    }

    public void BetOnClick(){
        switch(betNum){
            case 1: if(tili<=10){tip.GetMessage("The Maxinum Multiple Is "+betNum.ToString() + " Times");betNum = 1;}
            else{
                    betNum = 3;
                }
            break;
            case 3: if(tili<=50){tip.GetMessage("The Maxinum Multiple Is " + betNum.ToString() + " Times");betNum = 1;}
            else{
                    betNum = 5;
                }
            break;
            case 5: if(tili<=200){tip.GetMessage("The Maxinum Multiple Is " + betNum.ToString() + " Times");betNum = 1;}
            else{betNum = 10;}
            break;
            case 10: if(tili<=500){tip.GetMessage("The Maxinum Multiple Is " + betNum.ToString() + " Times");betNum = 1;}
            else{betNum = 20;}
            break;
            case 20: if(tili<=1000){tip.GetMessage("The Maxinum Multiple Is " + betNum.ToString() + " Times");betNum = 1;}
            else{betNum = 50;}
            break;
            case 50: if(tili<=2000){tip.GetMessage("The Maxinum Multiple Is " + betNum.ToString() + " Times");betNum = 1;}
            else{betNum = 100;}
            break;
            case 100: betNum = 1;break;
            default: break;
        }
        Bettext.text =" " + betNum;
    }

    public int GetRandom()
    {
        return Random.Range(0, 8);
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

    public void GetBigReward(int reward)
    {
        Invoke("HighLightClose", 1f);
        Invoke("RewardsHeadPosReset", 1f);
        rewardsHead1.SetActive(true);
        Tween t = rewardsHead1.transform.DOMove(new Vector3(rewardsPosition[reward].transform.position.x, rewardsPosition[reward].transform.position.y), 0.3f).SetEase(Ease.OutCubic);
        t.OnComplete(
          () =>
          {
              //调用闪烁函数
              //rewardsPosition[reward].GetComponent<HaloControl>().run = true;
              showRewardDh(reward, 8);
              rewardsHighLight[reward].SetActive(true);

          }
      );
        WhatReward(reward, 5);

    }

    public void GetMiddleReward(int reward)
    {
        Invoke("HighLightClose", 1f);
        Invoke("RewardsHeadPosReset", 1f);
        if (!pdTiliAndBigExp(reward))
        {
            rewardsHead1.SetActive(true);
            
            Tween t = rewardsHead1.transform.DOMove(new Vector3(rewardsPosition[reward].transform.position.x, rewardsPosition[reward].transform.position.y), 0.3f).SetEase(Ease.OutCubic);
            t.OnComplete(
               () =>
               {
               //调用闪烁函数
                   rewardsHighLight[reward].SetActive(true);

                   //rewardsPosition[reward].GetComponent<HaloControl>().run = true;
                   showRewardDh(reward, 5);
               }
           );

        }

        WhatReward(reward, 3);

    }

    public void GetSmallReward(int rewardA,int rewardB,int rewardC)
    {
        Invoke("HighLightClose",1f);
        Invoke("RewardsHeadPosReset", 1f);
        if (!pdTiliAndBigExp(rewardA))
        {
            rewardsHead1.SetActive(true);
            Tween t = rewardsHead1.transform.DOMove(new Vector3(rewardsPosition[rewardA].transform.position.x, rewardsPosition[rewardA].transform.position.y), 0.3f).SetEase(Ease.OutCubic);
            t.OnComplete(
            () =>
            {
                rewardsHighLight[rewardA].SetActive(true);
                //调用闪烁函数
                //rewardsPosition[rewardA].GetComponent<HaloControl>().run = true;
                showRewardDh(rewardA, 3);
            }
        );
        }
        if (!pdTiliAndBigExp(rewardB))
        {
            rewardsHead2.SetActive(true);
           
            Tween t = rewardsHead2.transform.DOMove(new Vector3(rewardsPosition[rewardB].transform.position.x, rewardsPosition[rewardB].transform.position.y), 0.3f).SetEase(Ease.OutCubic);
            t.OnComplete(
            () =>
            {
                rewardsHighLight[rewardB].SetActive(true);
                //rewardsPosition[rewardB].GetComponent<HaloControl>().run = true;
                showRewardDh(rewardB, 3);
            });
        }
        if (!pdTiliAndBigExp(rewardC))
        {
            rewardsHead3.SetActive(true);
           
            Tween t = rewardsHead3.transform.DOMove(new Vector3(rewardsPosition[rewardC].transform.position.x, rewardsPosition[rewardC].transform.position.y), 0.3f).SetEase(Ease.OutCubic);
            t.OnComplete(
            () =>
            {
                rewardsHighLight[rewardC].SetActive(true);
                // rewardsPosition[rewardC].GetComponent<HaloControl>().run = true;
                showRewardDh(rewardC, 3);
            }
        );
        }

        WhatReward(rewardA, 1);
        WhatReward(rewardB, 1);
        WhatReward(rewardC, 1);
    }

    public void RewardsHeadPosReset()
    {
        rewardsHead1.transform.position = centerObject.transform.position;
        rewardsHead2.transform.position = centerObject.transform.position;
        rewardsHead3.transform.position = centerObject.transform.position;
        rewardsHead1.SetActive(false);
        rewardsHead2.SetActive(false);
        rewardsHead3.SetActive(false);
    }

    public void HighLightClose()
    {
        for(int i = 0; i < 8; i++)
        {
            rewardsHighLight[i].SetActive(false);
        }
    }

    public void SlotGo()
    {
        //让小球分别获得奖励
        rewardA = GetRandom();
        rewardB = GetRandom();
        rewardC = GetRandom();

        if(SlotTime == 5)
        {
            SlotTime = 0;
            rewardB = rewardA;
            rewardC = rewardA;
        }

        simplePortalPurple.GetComponent<ParticleSystem>().Play();
       //确定小球停留位置，并设置其动画效果
        Tween t = pointC.transform.DORotate(new Vector3(0, 0, rewards[rewardA] - pointC.transform.eulerAngles.z - 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        t.OnComplete(
            () =>
            {
                //等动画播完后调用拿奖函数
                GetRewards(rewardA, rewardB, rewardC);
                //并让小球继续转动
                
                Invoke("ReverseStopFlag", 1f);
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
        // 更改体力
        if(changePower){
            globalPower.GetComponent<Text>().text = tili.ToString();
            changePower = false;
        }
        tili = int.Parse(globalPower.GetComponent<Text>().text);
        Tilitext.text = tili.ToString() + "/100";
        slider.value = tili;

        // 更改经验
        if(changeExp){
            globalExp.GetComponent<Text>().text = exp.ToString();
            changeExp = false;
        }
        exp = int.Parse(globalExp.GetComponent<Text>().text);
        expText.text = "✖" + exp;
    }

    //判断老虎机封装,grade判断奖励大小1.small;2.midlle;3.big;
    void WhatReward(int reward,int grade){
        //获得四元素
        switch (reward)
        {
            case 0 : Water = int.Parse(globalWaterRsData.GetComponent<Text>().text) + betNum * 100*grade;globalWaterRsData.GetComponent<Text>().text = Water.ToString();break;
            case 1 : Fire = int.Parse(globalFireRsData.GetComponent<Text>().text) + betNum * 100*grade;globalFireRsData.GetComponent<Text>().text = Fire.ToString();break;
            case 2 : Land = int.Parse(globalLandRsData.GetComponent<Text>().text) + betNum * 100*grade;globalLandRsData.GetComponent<Text>().text = Land.ToString();break;
            case 3 : Wind = int.Parse(globalWindRsData.GetComponent<Text>().text) + betNum * 100*grade;globalWindRsData.GetComponent<Text>().text = Wind.ToString();break;
            case 4 :
                if (grade == 5)
                {
                    exp = exp + 2000*betNum;
                    changeExp = true;
                }
                break;

               // 大经验
            case 5:
            case 7:
                exp = exp + grade * 100*betNum;
                changeExp = true;
                break;// 小经验
            case 6 : if(grade == 5){
                tili = tili + betNum * 10;
                changePower = true;
                break;
                }
                else{
                    break;
                }
            default: break;
        }
    }

    bool pdTiliAndBigExp(int reward){
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

                float StartX = positionX + Random.Range(-80,80);
                float StartY = positionY + Random.Range(-80,80);

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
                    ctrlPoints[2] = TiliObject.transform.position;
                }
                else if((reward == 4 || reward == 5) ||reward == 7){
                    ctrlPoints[2] = ExpPosition.transform.position;
                }
                else {
                    ctrlPoints[2] = centerObject.transform.position;
                }

                // 运动轨迹
                go.GetComponent<GetResource>().getIsStart(true, ctrlPoints);

            }
    }        
}
