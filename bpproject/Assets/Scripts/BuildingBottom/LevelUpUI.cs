using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelUpUI : MonoBehaviour
{
    public Button ok;
    public Button cancel;
    public int buildingLevel;
    public Text oldData;
    public Text newData;
    public Text text;
    public Text selectElement;

    public Text globalFire;
    public Text globalWater;
    public Text globalLand;
    public Text globalWind;
    public Message tips;
    // Start is called before the first frame update
    void Start()
    {
        oldData.text = "1%";
        newData.text = "2%";
        text.text = "All elements required to upgrade ×400";
        //whatElement();
        buildingLevel = 1;
        ok.onClick.AddListener(delegate () { OnClickOK(); });
        cancel.onClick.AddListener(delegate () { OnClickCancel(); });

    }

    public void whatElement()
    {
        if(selectElement.text == "fire")
        {
            text.text = "Fire element required to upgrade ×100";
        }else if (selectElement.text == "water")
        {
            text.text = "Water element required to upgrade ×100";
        }
        else if (selectElement.text == "w")
        {
            text.text = "Fire element required to upgrade ×100";
        }
        else if (selectElement.text == "water")
        {
            text.text = "Fire element required to upgrade ×100";
        }
    }

    public void OnClickCancel()
    {
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x + 1000, gameObject.transform.position.y), 0.5f);
    }

    public void OnClickOK()
    {
        if (Consume())
        {
            gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x + 1000, gameObject.transform.position.y), 0.5f);
            buildingLevel += 1;
            oldData.text = newData.text;
            newData.text = (buildingLevel + 1).ToString() + "%";
            text.text = "All elements required to upgrade ×" + (buildingLevel * 400).ToString();
        }

    }

    public bool Consume()
    {
        int fireTemp = int.Parse(globalFire.text) - buildingLevel*400;
        if (fireTemp < 0)
        {
            tips.GetMessage("Fire Element Not Enough");
            return false;
        }

        int waterTemp = int.Parse(globalWater.text) - buildingLevel * 400;
        if (waterTemp < 0)
        {
            tips.GetMessage("Water Element Not Enough");
            return false;
        }

        int windTemp = int.Parse(globalWind.text) - buildingLevel * 400;
        if (windTemp < 0)
        {
            tips.GetMessage("Wind Element Not Enough");
            return false;
        }

        int landTemp = int.Parse(globalLand.text) - buildingLevel * 400;
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
        
    }
}
