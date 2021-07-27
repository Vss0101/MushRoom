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
    public Button run;
    public bool stop;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public Image pointCForWater;
    public float angel;
    public int time;
    public int[] rewards;


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
         stop = true;
        SlotStop();
    }

    public int GetRandom()
    {
        return Random.Range(0, 4);
    }

    public void ReverseStopFlag()
    {
        stop = !stop;
        speedA = Random.Range(10,100);
        speedB = Random.Range(10, 100);
        speedC = Random.Range(10, 100);
    }

    public void SlotStop()
    {
        pointC.transform.DORotate(new Vector3(0, 0, rewards[GetRandom()] - pointC.transform.eulerAngles.z + 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        pointA.transform.DORotate(new Vector3(0, 0, rewards[GetRandom()] - pointA.transform.eulerAngles.z + 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        pointB.transform.DORotate(new Vector3(0, 0, rewards[GetRandom()] - pointB.transform.eulerAngles.z + 360 * 2), time, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        Invoke("ReverseStopFlag", time+1);
    }

    // Update is called once per frame
    void Update()
    {
        if(stop == false)
        {
            pointA.transform.Rotate(Vector3.forward, speedA * Time.deltaTime);
            pointB.transform.Rotate(Vector3.forward, speedB * Time.deltaTime);
            pointC.transform.Rotate(Vector3.forward, speedC * Time.deltaTime);
        }

    }
}
