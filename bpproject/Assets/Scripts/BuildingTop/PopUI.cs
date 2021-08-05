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
    public float scale;
    private bool isRepair;
    // Start is called before the first frame update
    void Start()
    {
        //scale = 1;
        isOpen = false;
        isRepair = false;
        building.onClick.AddListener(delegate () { OnClickForBuilding(); });
        wantRepair.onClick.AddListener(delegate () { OnClickForWantRepair(); });
        //EventListener.AddEventListenr(gameObject).onclick = OnClickFunc;
    }

    public void OnClickForWantRepair()
    {
        isRepair = true;
        buildingScaleControl();
        isOpen = false;
        notRepair.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
    }

    public void buildingScaleControl()
    {
        if (isOpen)
        {
            building.transform.DOScale(new Vector3(building.transform.localScale.x - 1, building.transform.localScale.y - 1), 0.5f);
        }
        else
        {
            building.transform.DOScale(new Vector3(building.transform.localScale.x + 1, building.transform.localScale.y + 1), 0.5f);
        }
    }

    public void OnClickForBuilding()
    {
        if (!isOpen)
        {
            buildingScaleControl();
            if (!isRepair)
            {
                notRepair.transform.DOScale(new Vector3(scale, scale, scale), 0.5f);
            }
            else
            {
                repair.transform.DOScale(new Vector3(scale, scale, scale), 0.5f);
            }
            isOpen = true;
        }
        else
        {
            buildingScaleControl();
            if (!isRepair)
            {
                notRepair.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
            }
            else
            {
                repair.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
            }
            isOpen = false;
        }
            
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
