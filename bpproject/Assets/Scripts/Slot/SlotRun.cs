using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlotRun : MonoBehaviour
{
    public Image pointASub;//小球
    public Image pointBSub;
    public Image pointCSub;
    public float speedA;//控制A球速度
    public float speedB;
    public float speedC;
    public int rewardA;//A球获得的奖励
    public int rewardB;
    public int rewardC;
    public Button run;//祈祷按钮
    public GameObject pointA;//小球父对象，控制转动角度
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointForWater;//奖励所在位置
    public GameObject pointForFire;
    public GameObject pointForWind;
    public GameObject pointForLand;
    public int time;
    public int[] rewards;//奖励列表
    public GameObject resource;//弹出的奖励图标
    public GameObject[] rewardsPosition;//奖励列表对应的位置

    public int tili;//体力数据
    public Text Tilitext;//显示体力


    // Start is called before the first frame update
    void Start()
    {
        //设置小球初始位置
        pointA.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        pointB.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        pointC.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        //设置奖励列表以及奖励对应图标
        rewards = new int[4] { 45, 135, 225, 315 };
        rewardsPosition = new GameObject[4] { pointForLand,pointForWater,pointForFire,pointForWind };
        //小球初始速度
        speedA = 30;
        speedB = 30;
        speedC = 30;
        time = 3;

        tili = 2;
        Tilitext.text = tili.ToString();
        run.onClick.AddListener(delegate () { OnClick(); });
    }

    //点击按钮后开始调用老虎机转动函数
    public void OnClick()
    {
        if(tili<=0){
            run.enabled = false;
        }
        else{
            tili = tili - 1;
            speedA = 0;
            speedB = 0;
            speedC = 0;
            Tilitext.text = tili.ToString();
            SlotGo();
        }
        //禁用祈祷按钮，防止玩家疯狂按
        run.enabled = false;
        
    }

    public int GetRandom()
    {
        return Random.Range(0, 4);
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
        for (int i = 0; i < 5; i++)
        {
            float positionX = rewardsPosition[reward].transform.position.x;
            float positionY = rewardsPosition[reward].transform.position.y;
            GameObject go = GameObject.Instantiate(resource, new Vector3(positionX + Random.Range(0, 50), positionY + Random.Range(0, 50), 0), Quaternion.identity);
            go.transform.SetParent(rewardsPosition[reward].transform);
        }
    }

    public void GetSmallReward()
    {

    }

    public void GetBigReward(int reward)
    {
        //调用闪烁函数
        rewardsPosition[reward].GetComponent<HaloControl>().run = true;
        //在对应奖励位置附近生成5个奖励图标，每个奖励图标自身有代码可以控制飞到某个位置自行销毁
        for (int i = 0; i < 5; i++)
        {
            float positionX= rewardsPosition[reward].transform.position.x;
            float positionY = rewardsPosition[reward].transform.position.y;
            GameObject go =GameObject.Instantiate(resource, new Vector3(positionX + Random.Range(0, 50), positionY + Random.Range(0, 50), 0), Quaternion.identity);
            go.transform.SetParent(rewardsPosition[reward].transform);
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
    }
}
