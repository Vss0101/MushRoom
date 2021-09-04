using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UnlockControl : MonoBehaviour
{
    public GameObject globalUnlockData;
    public Image image;
    public Sprite unLockImage;
    public bool isUnlock;
    public int level;
    public float scale;
    public float scaleForPop;
    public GameObject popUI;
    public Button unlock;
    public GameObject content;

    public GameObject pos1;
    public GameObject pos2;

    public Text globalLand;
    public Text globalWater;
    public Text globalWind;
    public Text globalFire;

    public Message tips;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        isUnlock = false;
        gameObject.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelect(); });
        unlock.onClick.AddListener(delegate () { OnClickUnlock(); });
        scale = 0.2f;
        scaleForPop = 0.8f;
        
    }

    public void OnClickSelect()
    {
        if (int.Parse(globalUnlockData.GetComponent<Text>().text) != level)
        {

        }
        else if (!isUnlock)
        {
            popUI.transform.DOScale(new Vector3(popUI.transform.localScale.x+scaleForPop, popUI.transform.localScale.y+ scaleForPop), 0.5f);
           Tween t = image.transform.DOScale(new Vector3(image.transform.localScale.x + scale, image.transform.localScale.y + scale), 0.5f);
            gameObject.GetComponent<Button>().enabled = false;
            t.OnComplete(
            () =>
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
        );
            scale *= -1;
            scaleForPop *= -1;
        }
    }

    public void OnClickUnlock()
    {

        if (Consume())
        {
            popUI.transform.DOScale(new Vector3(0, 0), 0.5f);
            isUnlock = true;
            image.sprite = unLockImage;
            image.transform.DOScale(new Vector3(image.transform.localScale.x - scale, image.transform.localScale.y - scale), 0.5f);
            globalUnlockData.GetComponent<Text>().text = (int.Parse(globalUnlockData.GetComponent<Text>().text) + 1).ToString();
            if ((int.Parse(globalUnlockData.GetComponent<Text>().text) - 1) % 3 == 0)
            {
                content.transform.DOMove(new Vector3(content.transform.position.x, content.transform.position.y - (pos2.transform.position.y - pos1.transform.position.y)), 1f);
            }
        }

    }

    public bool Consume()
    {
        int fireTemp = int.Parse(globalFire.text) - int.Parse(globalUnlockData.GetComponent<Text>().text) * 500;
        if (fireTemp < 0)
        {
            tips.GetMessage("Fire Element Not Enough");
            return false;
        }

        int waterTemp = int.Parse(globalWater.text) - int.Parse(globalUnlockData.GetComponent<Text>().text) * 500;
        if (waterTemp < 0)
        {
            tips.GetMessage("Water Element Not Enough");
            return false;
        }

        int windTemp = int.Parse(globalWind.text) - int.Parse(globalUnlockData.GetComponent<Text>().text) * 500;
        if (windTemp < 0)
        {
            tips.GetMessage("Wind Element Not Enough");
            return false;
        }

        int landTemp = int.Parse(globalLand.text) - int.Parse(globalUnlockData.GetComponent<Text>().text) * 500;
        if (landTemp < 0)
        {
            tips.GetMessage("Earth Element Not Enough");
            return false;
        }



        globalFire.text = fireTemp.ToString();
        globalWater.text = waterTemp.ToString();
        globalWind.text = windTemp.ToString();
        globalLand.text = landTemp.ToString();
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Need to consume all elements ×" + (int.Parse(globalUnlockData.GetComponent<Text>().text) * 500).ToString();
    }
}
