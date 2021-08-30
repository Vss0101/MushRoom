using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CollectResource : MonoBehaviour
{
    //由于没有数据库，使用了全局资源作为暂时的数据存储，所以需要传入很多参数
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


    //三份近乎重复的代码，但在经验魔力和元素收集表现间细节上有些不同
    //并且元素收集需要四种数据一起判断和收集表现，所以就算复用也需要分成两份几乎相同的代码，或者设计一个合理的接口
    //懒得设计了，怎么快怎么来
    public Sprite empty;

    public Image EXPUI;
    public GameObject floatEXPUI;
    private CanvasGroup popEXPCanvasGroup;
    private CanvasGroup floatEXPCanvasGroup;
    public Button collectEXPBtn;
    private Vector3 startEXPPosition;
    private Vector3 startEXPScale;
    private Vector3 floatStartEXPPosition;
    public Text expText;
    public Sprite smallEXP;
    public Sprite middleEXP;
    public Sprite bigEXP;
    public Image bubbleEXP;


    public Image PowerUI;
    public GameObject floatPowerUI;
    private CanvasGroup popPowerCanvasGroup;
    private CanvasGroup floatPowerCanvasGroup;
    public Button collectPowerBtn;
    private Vector3 startPowerPosition;
    private Vector3 startPowerScale;
    private Vector3 floatStartPowerPosition;
    public Text powerText;
    public Sprite smallPower;
    public Sprite middlePower;
    public Sprite bigPower;
    public Image bubblePower;

    public Image ResourceUI;
    public GameObject floatResourceUI;
    private CanvasGroup popResourceCanvasGroup;
    private CanvasGroup floatResourceCanvasGroup;
    public Button collectResourceBtn;
    private Vector3 startResourcePosition;
    private Vector3 startResourceScale;
    private Vector3 floatStartResourcePosition;
    public Text landText;
    public Text fireText;
    public Text waterText;
    public Text windText;
    public Sprite smallResource;
    public Sprite middleResource;
    public Sprite bigResource;
    public Image bubbleResource;

    // Start is called before the first frame update
    void Start()
    {
        startEXP();
        startPower();
        startResource();
    }

    public void startEXP()
    {
        popEXPCanvasGroup = EXPUI.GetComponent<CanvasGroup>();
        floatEXPCanvasGroup = floatEXPUI.GetComponent<CanvasGroup>();
        collectEXPBtn = EXPUI.GetComponent<Button>();
        collectEXPBtn.onClick.AddListener(delegate () { OnClickCollectEXP(); });
        popEXPCanvasGroup.alpha = 0;
        floatEXPCanvasGroup.alpha = 0;
        startEXPPosition = EXPUI.transform.position;
        startEXPScale = EXPUI.transform.localScale;
        floatStartEXPPosition = floatEXPUI.transform.position;
        collectEXPBtn.enabled = false;
    }

    public void startPower()
    {
        popPowerCanvasGroup = PowerUI.GetComponent<CanvasGroup>();
        floatPowerCanvasGroup = floatPowerUI.GetComponent<CanvasGroup>();
        collectPowerBtn = PowerUI.GetComponent<Button>();
        collectPowerBtn.onClick.AddListener(delegate () { OnClickCollectPower(); });
        popPowerCanvasGroup.alpha = 0;
        floatPowerCanvasGroup.alpha = 0;
        startPowerPosition = PowerUI.transform.position;
        startPowerScale = PowerUI.transform.localScale;
        floatStartPowerPosition = floatPowerUI.transform.position;
        collectPowerBtn.enabled = false;
    }

    public void startResource()
    {
        popResourceCanvasGroup = ResourceUI.GetComponent<CanvasGroup>();
        floatResourceCanvasGroup = floatResourceUI.GetComponent<CanvasGroup>();
        collectResourceBtn = ResourceUI.GetComponent<Button>();
        collectResourceBtn.onClick.AddListener(delegate () { OnClickCollectResource(); });
        popResourceCanvasGroup.alpha = 0;
        floatResourceCanvasGroup.alpha = 0;
        startResourcePosition = ResourceUI.transform.position;
        startResourceScale = ResourceUI.transform.localScale;
        floatStartResourcePosition = floatResourceUI.transform.position;
        collectResourceBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        EXPUpdate();
        PowerUpdate();
        ResourceUpdate();
    }

    public void OnClickCollectEXP()
    {
        if (popEXPCanvasGroup.alpha ==1)
        {
            popEXPCanvasGroup.alpha = 0;
            floatEXPCanvasGroup.alpha = 1;
            globalEXP.text = (int.Parse(globalEXP.text) +int.Parse(produceEXP.text)).ToString();
            expText.text = "+" + produceEXP.text;
            produceEXP.text = "0";
            bubbleEXP.sprite = empty;
            Tween t = floatEXPUI.transform.DOMove(new Vector3(floatStartEXPPosition.x, floatStartEXPPosition.y + 200), 1f);
            t.OnUpdate(
            () =>
            {
                floatEXPCanvasGroup.alpha -= 1*Time.deltaTime;
            }
        );
            t.OnComplete(
             () =>
             {
                 floatEXPCanvasGroup.alpha = 0;
             }
         );

            collectEXPBtn.enabled = false;
        }
    }

    public void OnClickCollectPower()
    {
        if (popPowerCanvasGroup.alpha == 1)
        {
            popPowerCanvasGroup.alpha = 0;
            floatPowerCanvasGroup.alpha = 1;
            globalPower.text = (int.Parse(globalPower.text) + int.Parse(producePower.text)).ToString();
            powerText.text = "+" + producePower.text;
            producePower.text = "0";
            bubblePower.sprite = empty;
            Tween t = floatPowerUI.transform.DOMove(new Vector3(floatStartPowerPosition.x, floatStartPowerPosition.y + 200), 1f);
            t.OnUpdate(
            () =>
            {
                floatPowerCanvasGroup.alpha -= 1 * Time.deltaTime;
            }
        );
            t.OnComplete(
             () =>
             {
                 floatPowerCanvasGroup.alpha = 0;
             }
         );

            collectPowerBtn.enabled = false;
        }
    }

    public void OnClickCollectResource()
    {
        if (popResourceCanvasGroup.alpha == 1)
        {
            popResourceCanvasGroup.alpha = 0;
            floatResourceCanvasGroup.alpha = 1;
            globalLand.text = (int.Parse(globalLand.text) + int.Parse(produceLand.text)).ToString();
            globalWater.text = (int.Parse(globalWater.text) + int.Parse(produceWater.text)).ToString();
            globalWind.text = (int.Parse(globalWind.text) + int.Parse(produceWind.text)).ToString();
            globalFire.text = (int.Parse(globalFire.text) + int.Parse(produceFire.text)).ToString();
            landText.text = "+" + produceLand.text;
            waterText.text = "+" + produceWater.text;
            fireText.text = "+" + produceFire.text;
            windText.text = "+" + produceWind.text;
            produceLand.text = "0";
            produceWater.text = "0";
            produceWind.text = "0";
            produceFire.text = "0";
            bubbleResource.sprite = empty;
            Tween t = floatResourceUI.transform.DOMove(new Vector3(floatStartResourcePosition.x, floatStartResourcePosition.y + 200), 1f);
            t.OnUpdate(
            () =>
            {
                floatResourceCanvasGroup.alpha -= 1 * Time.deltaTime;
            }
        );
            t.OnComplete(
             () =>
             {
                 floatResourceCanvasGroup.alpha = 0;
             }
         );

            collectResourceBtn.enabled = false;
        }
    }

    public void EXPReset()
    {
        EXPUI.transform.position = startEXPPosition;
        EXPUI.transform.localScale = startEXPScale;
        floatEXPUI.transform.position = floatStartEXPPosition;
    }

    public void PowerReset()
    {
        PowerUI.transform.position = startPowerPosition;
        PowerUI.transform.localScale = startPowerScale;
        floatPowerUI.transform.position = floatStartPowerPosition;
    }

    public void ResourceReset()
    {
        ResourceUI.transform.position = startResourcePosition;
        ResourceUI.transform.localScale = startResourceScale;
        floatResourceUI.transform.position = floatStartResourcePosition;
    }

    public void EXPUpdate()
    {
        int exp = (int.Parse(produceEXP.text));
        if (exp >=2 && exp <5)
        {
            EXPReset();
            popEXPCanvasGroup.alpha = 0.3f;
        }
        else if ( exp>= 5 && exp <10)
        {
            EXPReset();
            popEXPCanvasGroup.alpha = 1;
            collectEXPBtn.enabled = true;
            bubbleEXP.sprite = smallEXP;

        }
        else if(exp >= 10 &&exp<20)
        {
            EXPReset();
            popEXPCanvasGroup.alpha = 1;
            collectEXPBtn.enabled = true;
            EXPUI.transform.DOScale(new Vector3(0.8f, 0.8f), 0.5f);
            bubbleEXP.sprite = middleEXP;
        }
        else if (exp >= 20)
        {
            EXPReset();
            popEXPCanvasGroup.alpha = 1;
            collectEXPBtn.enabled = true;
            EXPUI.transform.DOScale(new Vector3(1f, 1f), 0.5f);
            bubbleEXP.sprite = bigEXP;
        }
    }

    public void PowerUpdate()
    {
        int power = (int.Parse(producePower.text));
        if (power >= 2 && power < 5)
        {
            PowerReset();
            popPowerCanvasGroup.alpha = 0.3f;
        }
        else if (power >= 5 && power < 10)
        {
            PowerReset();
            popPowerCanvasGroup.alpha = 1;
            collectPowerBtn.enabled = true;
            bubblePower.sprite = smallPower;
        }
        else if (power >= 10 && power < 20)
        {
            PowerReset();
            popPowerCanvasGroup.alpha = 1;
            collectPowerBtn.enabled = true;
            PowerUI.transform.DOScale(new Vector3(0.8f, 0.8f), 0.5f);
            bubblePower.sprite = middlePower;
        }
        else if (power >= 20)
        {
            PowerReset();
            popPowerCanvasGroup.alpha = 1;
            collectPowerBtn.enabled = true;
            PowerUI.transform.DOScale(new Vector3(1f, 1f), 0.5f);
            bubblePower.sprite = bigPower;
        }
    }

    public void ResourceUpdate()
    {
        int resource = int.Parse(produceLand.text)+ int.Parse(produceWater.text)+ int.Parse(produceWind.text)+ int.Parse(produceFire.text);
        if (resource >= 8 && resource < 20)
        {
            ResourceReset();
            popResourceCanvasGroup.alpha = 0.3f;
        }
        else if (resource >= 20 && resource < 40)
        {
            ResourceReset();
            popResourceCanvasGroup.alpha = 1;
            collectResourceBtn.enabled = true;
            bubbleResource.sprite = smallResource;
        }
        else if (resource >= 40 && resource < 80)
        {
            ResourceReset();
            popResourceCanvasGroup.alpha = 1;
            collectResourceBtn.enabled = true;
            ResourceUI.transform.DOScale(new Vector3(0.8f, 0.8f), 0.5f);
            bubbleResource.sprite = middleResource;
        }
        else if (resource >= 80)
        {
            ResourceReset();
            popResourceCanvasGroup.alpha = 1;
            collectResourceBtn.enabled = true;
            ResourceUI.transform.DOScale(new Vector3(1f, 1f), 0.5f);
            bubbleResource.sprite = bigResource;
        }
    }
}
