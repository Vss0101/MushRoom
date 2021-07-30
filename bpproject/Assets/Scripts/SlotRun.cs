using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlotRun : MonoBehaviour
{
    public Image pointASub;
    public Image pointBSub;
    public Image pointCSub;
    public float speedA;
    public float speedB;
    public float speedC;
    public int rewardA;
    public int rewardB;
    public int rewardC;
    public Button run;
    public bool stop;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public Image pointCForWater;
    public float angel;
    public int time;
    public int[] rewards;
    public GameObject resource;


    // Start is called before the first frame update
    void Start()
    {
        pointA.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        pointB.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        pointC.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        rewards = new int[4] { 45, 135, 225, 315 };
        stop = false;
        speedA = 30;
        speedB = 30;
        speedC = 30;
        time = 3;
        run.onClick.AddListener(delegate () { OnClick(); });
    }

    public void OnClick()
    {
        speedA = 0;
        speedB = 0;
        speedC = 0;
        SlotStop();
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
        if(rewardA == rewardB && rewardC == rewardA)
        {
            GetBigReward(rewardA);
        }else if(rewardA == rewardB || rewardA == rewardC || rewardB == rewardC)
        {
            GetBigReward(rewardA);
            GetMiddleReward();
        }
        else
        {
            GetSmallReward();
        }
    }

    public void GetMiddleReward()
    {

    }

    public void GetSmallReward()
    {

    }

    public void GetBigReward(int reward)
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject go =GameObject.Instantiate(resource, new Vector3(pointCForWater.transform.position.x + Random.Range(0, 50), pointCForWater.transform.position.y + Random.Range(0, 50), 0), Quaternion.identity);
            go.transform.SetParent(pointCForWater.transform);
        }
    }

    public void SlotStop()
    {
        rewardA = GetRandom();
        rewardB = GetRandom();
        rewardC = GetRandom();
        Tween t = pointC.transform.DORotate(new Vector3(0, 0, rewards[rewardA] - pointC.transform.eulerAngles.z + 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        t.OnComplete(
            () =>
            {
                GetRewards(rewardA, rewardB, rewardC);
                ReverseStopFlag();
            }
        );
        pointA.transform.DORotate(new Vector3(0, 0, rewards[rewardB] - pointA.transform.eulerAngles.z + 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        pointB.transform.DORotate(new Vector3(0, 0, rewards[rewardC] - pointB.transform.eulerAngles.z + 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
    }

    // Update is called once per frame
    void Update()
    {
            pointA.transform.Rotate(Vector3.forward, speedA * Time.deltaTime);
            pointB.transform.Rotate(Vector3.forward, speedB * Time.deltaTime);
            pointC.transform.Rotate(Vector3.forward, speedC * Time.deltaTime);
    }
}
