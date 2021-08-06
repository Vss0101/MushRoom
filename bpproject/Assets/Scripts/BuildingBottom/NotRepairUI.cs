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
    // Start is called before the first frame update
    void Start()
    {
       bFire.onClick.AddListener(delegate () { OnClickFire(); });
       bWater.onClick.AddListener(delegate () { OnClickWater(); });
       bWind.onClick.AddListener(delegate () { OnClickWind(); });
       bLand.onClick.AddListener(delegate () { OnClickLand(); });
       ok.onClick.AddListener(delegate () { OnClickOK(); });
       cancel.onClick.AddListener(delegate () { OnClickCancel(); });
    }

    public void OnClickCancel(){
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x+800,gameObject.transform.position.y),0.5f);
    }

    public void OnClickOK(){
        building.GetComponent<PopUI>().building.image.sprite = resource.sprite;
        building.GetComponent<PopUI>().isRepair = true;
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x+800,gameObject.transform.position.y),0.5f);
    }

    public void OnClickFire(){
        resource.sprite = sFire;
    }

    public void OnClickWater(){
        resource.sprite = sWater;
    }

    public void OnClickLand(){
        resource.sprite = sLand;
    }

    public void OnClickWind(){
        resource.sprite = sWind;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
