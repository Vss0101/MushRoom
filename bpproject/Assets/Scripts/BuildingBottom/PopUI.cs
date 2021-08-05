using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopUI : MonoBehaviour
{
    public Button building;
    public Button wantRepair;
    public GameObject notRepair;
    public GameObject repair;
    public Image buildingA;
    public bool isOpen;
    public float scaleForUI;
    public float scaleForBuilding;
    private bool isRepair;
    public GameObject notRepairUI;
    public GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        isRepair = false;
        scaleForBuilding = 1;
        building.onClick.AddListener(delegate () { OnClickForBuilding(); });
        wantRepair.onClick.AddListener(delegate () { OnClickForWantRepair(); });
    }

    public void OnClickForWantRepair()
    {
        isRepair = true;
        if(scaleForUI<0){
            scaleForUI = -scaleForUI;
        }
        buildingScaleControl();
        notRepair.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
    }

    public void buildingScaleControl()
    {
        building.transform.DOScale(new Vector3(building.transform.localScale.x + scaleForBuilding, building.transform.localScale.y + scaleForBuilding), 0.5f);
        scaleForBuilding = -scaleForBuilding;
    }

    public void OnClickForBuilding()
    {
        //buildingScaleControl();
        if (!isRepair)
        {
            notRepairUI.transform.DOMove(new Vector3(center.transform.position.x,notRepairUI.transform.position.y),0.5f);
            //notRepair.transform.DOScale(new Vector3(notRepair.transform.localScale.x+scaleForUI, notRepair.transform.localScale.x+scaleForUI), 0.5f);
            //scaleForUI = -scaleForUI;
        }
        else
        {
            buildingScaleControl();
            repair.transform.DOScale(new Vector3(repair.transform.localScale.x+scaleForUI, repair.transform.localScale.x+scaleForUI), 0.5f);
            scaleForUI = -scaleForUI;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
