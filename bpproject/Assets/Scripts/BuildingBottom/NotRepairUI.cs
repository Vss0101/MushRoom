using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NotRepairUI : MonoBehaviour
{
    public Button bFire;
    public Button bWater;
    public Button bWind;
    public Button bLand;
    public Image resource;
    public Sprite sFire;
    public Sprite sWater;
    public Sprite sWind;
    public Sprite sLand;
    public Button ok;
    public Button cancel;
    public GameObject building;

    public Sprite darkLight;
    public Sprite highLight;
    public Image fire;
    public Image water;
    public Image wind;
    public Image land;
    public Text text;

    public Text globalFire;
    public Text globalWater;
    public Text globalLand;
    public Text globalWind;

    public Message tips;

    public GameObject message;
    public Image messageResource;

    public GameObject shouldRepairUI;
    // Start is called before the first frame update
    void Start()
    {
        resource.sprite = sLand;
        darkLight = land.sprite;
        land.sprite = highLight;
        text.text = "Consume 100 Earth elements to repair the building";
        bFire.onClick.AddListener(delegate () { OnClickFire(); });
       bWater.onClick.AddListener(delegate () { OnClickWater(); });
       bWind.onClick.AddListener(delegate () { OnClickWind(); });
       bLand.onClick.AddListener(delegate () { OnClickLand(); });
       ok.onClick.AddListener(delegate () { OnClickOK(); });
       cancel.onClick.AddListener(delegate () { OnClickCancel(); });
    }

    public void OnClickCancel(){
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x+ 1000, gameObject.transform.position.y),0.5f);
        building.GetComponent<PopUI>().isSelectImageControl();
    }

    public void OnClickOK(){
        if (ConsumeResource())
        {
            shouldRepairUI.SetActive(false);
            building.GetComponent<PopUI>().building.image.sprite = resource.sprite;
            building.GetComponent<PopUI>().isRepair = true;
            gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x + 1000, gameObject.transform.position.y), 0.5f);
            message.SetActive(true);
            messageResource.sprite = resource.sprite;
            building.GetComponent<PopUI>().isSelectImageControl();
        }
        
    }

    public bool ConsumeResource()
    {
        if(resource.sprite == sFire)
        {
            int temp = int.Parse(globalFire.text) - 100;
            if (temp < 0)
            {
                tips.GetMessage("Fire Element Not Enough");
                return false;
            }
            globalFire.text = temp.ToString();
        }else if (resource.sprite == sWater)
        {
          int temp = int.Parse(globalWater.text) - 100;
            if (temp < 0)
            {
                tips.GetMessage("Water Element Not Enough");
                return false;
            }
            globalWater.text = temp.ToString();
        }
        else if (resource.sprite == sWind)
        {
            int temp = int.Parse(globalWind.text) - 100;
            if (temp < 0)
            {
                tips.GetMessage("Wind Element Not Enough");
                return false;
            }
            globalWind.text = temp.ToString();
        }
        else if (resource.sprite == sLand)
        {
            int temp = int.Parse(globalLand.text) - 100;
            if (temp < 0)
            {
                tips.GetMessage("Earth Element Not Enough");
                return false;
            }
            globalLand.text = temp.ToString();
        }
        return true;
    }

    public void ResetAll()
    {
        fire.sprite = darkLight;
        land.sprite = darkLight;
        water.sprite = darkLight;
        wind.sprite = darkLight;
    }

    public void OnClickFire(){
        ResetAll();
        fire.sprite = highLight;
        resource.sprite = sFire;
        text.text = "Consume 100 Fire elements to repair the building";

    }

    public void OnClickWater(){
        ResetAll();
        water.sprite = highLight;
        resource.sprite = sWater;
        text.text = "Consume 100 Water elements to repair the building";
    }

    public void OnClickLand(){
        ResetAll();
        land.sprite = highLight;
        resource.sprite = sLand;
        text.text = "Consume 100 Earth elements to repair the building";
    }

    public void OnClickWind(){
        ResetAll();
        wind.sprite = highLight;
        resource.sprite = sWind;
        text.text = "Consume 100 Wind elements to repair the building";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
