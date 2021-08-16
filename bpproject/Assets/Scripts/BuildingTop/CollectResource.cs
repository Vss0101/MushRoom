using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CollectResource : MonoBehaviour
{
    public Text produceEXP;
    public Text producePower;
    public Text produceLand;
    public Text produceWater;
    public Text produceWind;
    public Text produceFire;
    public Text globalEXP;
    public Text globalPower;
    public Text globalWater;
    public Text globalFire;
    public Text globalWind;
    public Text globalLand;

    public Image EXPUI;
    public GameObject floatUI;
    private CanvasGroup popCanvasGroup;
    private CanvasGroup floatCanvasGroup;
    public Button collectBtn;
    public Vector3 startPosition;
    public Vector3 startScale;
    public Vector3 floatStartPosition;
    public Text text;


    // Start is called before the first frame update
    void Start()
    {
        popCanvasGroup = EXPUI.GetComponent<CanvasGroup>();
        floatCanvasGroup = floatUI.GetComponent<CanvasGroup>();
        collectBtn = EXPUI.GetComponent<Button>();
        collectBtn.onClick.AddListener(delegate () { OnClickCollect(); });
        popCanvasGroup.alpha = 0;
        floatCanvasGroup.alpha = 0;
        startPosition = EXPUI.transform.position;
        startScale = EXPUI.transform.localScale;
        floatStartPosition = floatUI.transform.position;
        collectBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        EXPUpdate();
        PowerUpdate();
        ResourceUpdate();
    }

    public void OnClickCollect()
    {
        if (popCanvasGroup.alpha ==1)
        {
            popCanvasGroup.alpha = 0;
            floatCanvasGroup.alpha = 1;
            globalEXP.text = (int.Parse(globalEXP.text) +int.Parse(produceEXP.text)).ToString();
            text.text = "+" + produceEXP.text;
            produceEXP.text = "0";
            Tween t = floatUI.transform.DOMove(new Vector3(floatStartPosition.x, floatStartPosition.y + 200), 1f);
            t.OnUpdate(
            () =>
            {
                floatCanvasGroup.alpha -= 1*Time.deltaTime;
            }
        );
            t.OnComplete(
             () =>
             {
                 floatCanvasGroup.alpha = 0;
             }
         );

            collectBtn.enabled = false;
        }
    }

    public void EXPReset()
    {
        EXPUI.transform.position = startPosition;
        EXPUI.transform.localScale = startScale;
        floatUI.transform.position = floatStartPosition;
    }

    public void EXPUpdate()
    {
        if (int.Parse(produceEXP.text) == 2)
        {
            EXPReset();
            popCanvasGroup.alpha = 0.3f;
        }
        else if (int.Parse(produceEXP.text) == 5)
        {
            popCanvasGroup.alpha = 1;
            collectBtn.enabled = true;
        }
        else if(int.Parse(produceEXP.text) == 10)
        {
            EXPUI.transform.DOScale(new Vector3(0.8f, 0.8f), 0.5f);
        }
        else if (int.Parse(produceEXP.text) == 20)
        {
            EXPUI.transform.DOScale(new Vector3(1f, 1f), 0.5f);
        }
    }

    public void PowerUpdate()
    {

    }

    public void ResourceUpdate()
    {

    }
}
