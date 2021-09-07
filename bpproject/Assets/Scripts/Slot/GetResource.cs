using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System;
using ForeverNine.MagicCoast;

public class GetResource : MonoBehaviour
{
    public Image imageReward;
    public int rewardResource;
    public bool isStart = false;
    public Vector3[] ctrlPoints = new Vector3[3];

    // 换图片pointForWater,pointForFire,pointForLand,pointForWind,bigEXP,smallEXP1,power,smallEXP2
    public void changePicture(int reward){
        switch (reward)
            {
                case 0 :imageReward.sprite = Resources.Load<Sprite>("水");break;
                case 1 :imageReward.sprite = Resources.Load<Sprite>("火");break;
                case 2 :imageReward.sprite = Resources.Load<Sprite>("地");break;
                case 3 :imageReward.sprite = Resources.Load<Sprite>("风");break;
                case 4 :imageReward.sprite = Resources.Load<Sprite>("小经验");break;
                case 5 :imageReward.sprite = Resources.Load<Sprite>("小经验");break;
                case 6 :imageReward.sprite = Resources.Load<Sprite>("小魔力");break;
                case 7 :imageReward.sprite = Resources.Load<Sprite>("小经验");break;
                case 8 :imageReward.sprite = Resources.Load<Sprite>("新小经验");break;
                default: break;
            }
            rewardResource = reward;
    }
        
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart){
            changePosition();
            isStart = false;
        }

    }

    public void getIsStart(bool isWhat, Vector3[] ctrlPointsTemp){
        for(int i=0; i<3; i++){
            ctrlPoints[i] = ctrlPointsTemp[i];
        }
        isStart = isWhat;
    }

    public void changePosition(){
        Tween t = TweenUtils.BezierToByWorldPosition(gameObject.transform, ctrlPoints, 1.2f).SetEase(Ease.InSine);
                t.OnComplete(
                () =>
                   {
                        GameObject.Destroy(gameObject);
                   }
                );
    }
}
