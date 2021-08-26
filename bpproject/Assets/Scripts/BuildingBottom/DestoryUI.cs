using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DestoryUI : MonoBehaviour
{
    public Button ok;
    public Button cancel;
    public Text text;
    public GameObject message;
    public GameObject building;
    public GameObject buildingLeavelUp;
    public Sprite noSelect;
    public Image characterLive;

    public Text globalFire;
    public Text globalWater;
    public Text globalLand;
    public Text globalWind;

    // Start is called before the first frame update
    void Start()
    {
        ok.onClick.AddListener(delegate () { OnClickOK(); });
        cancel.onClick.AddListener(delegate () { OnClickCancel(); });
        text.text = "Destroying buildings will return 80% of resources";
    }

    public void OnClickCancel()
    {
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x + 1000, gameObject.transform.position.y), 0.5f);
    }

    public void OnClickOK()
    {
        int i = buildingLeavelUp.GetComponent<LevelUpUI>().buildingLevel;
        int temp = (int)((i * 400 - 400) * 0.8f);
        if(temp < 0)
        {
            temp = 0;
        }
        globalFire.text = (int.Parse(globalFire.text) + temp).ToString();
        globalWater.text = (int.Parse(globalWater.text) + temp).ToString();
        globalWind.text = (int.Parse(globalWind.text) + temp).ToString();
        globalLand.text = (int.Parse(globalLand.text) + temp).ToString();
        buildingLeavelUp.GetComponent<LevelUpUI>().Reset();
        building.GetComponent<PopUI>().isRepair = false;
        message.SetActive(false);
        characterLive.sprite = noSelect;

        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x + 1000, gameObject.transform.position.y), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
