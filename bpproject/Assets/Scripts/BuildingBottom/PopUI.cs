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
    // public Image buildingA;
    public bool isOpen;
    public float scaleForUIY;
    public float scaleForUIX;
    public float scaleForBuilding;
    public bool isRepair;
    public Sprite selectImage;
    public Sprite unSelectImage;
    public GameObject notRepairUI;
    public GameObject center;
    public bool isSelect;

    public GameObject message;

    public Button levelUp;
    public GameObject levelUpUI;

    public Button characterLive;
    public GameObject characterLiveUI;

    public Button destory;
    public GameObject destoryUI;

    public GameObject shouldRepair;
    public int uiMove;

    // Start is called before the first frame update
    void Start()
    {
        isRepair = false;
        isSelect = false;
        scaleForBuilding = 1;
        unSelectImage = gameObject.GetComponent<Image>().sprite;
        building.onClick.AddListener(delegate () { OnClickForBuilding(); });
        wantRepair.onClick.AddListener(delegate () { OnClickForWantRepair(); });
        levelUp.onClick.AddListener(delegate () { OnClickForLevelUp(); });
        characterLive.onClick.AddListener(delegate () { OnClickForLiveIn(); });
        destory.onClick.AddListener(delegate () { OnClickForDestory(); });
        shouldRepair.GetComponent<Button>().onClick.AddListener(delegate () { OnClickForBuildingToo(); });
        uiMove = 20;
        uiUpdate();
    }

    public void uiUpdate()
    {
        float time = 0;
        if(uiMove > 0)
        {
            time = 1.5f;
        }else
        {
            time = 0.5f;
        }
        Tween t = shouldRepair.transform.DOMove(new Vector3(shouldRepair.transform.position.x, shouldRepair.transform.position.y + uiMove), time);
        t.OnComplete(
            () =>
            {
                uiMove *= -1;
                uiUpdate();
            }
        );

    }

    public void OnClickForBuildingToo()
    {
        OnClickForBuilding();
    }

    public void OnClickForDestory()
    {
        destoryUI.transform.DOMove(new Vector3(center.transform.position.x, notRepairUI.transform.position.y), 0.5f);
        //buildingScaleControl();
        isSelectImageControl();
        repairScaleControl();
    }

    public void OnClickForLiveIn()
    {
        characterLiveUI.transform.DOMove(new Vector3(center.transform.position.x, notRepairUI.transform.position.y), 0.5f);
        //buildingScaleControl();
        isSelectImageControl();
        repairScaleControl();
    }

    public void OnClickForLevelUp()
    {
        levelUpUI.transform.DOMove(new Vector3(center.transform.position.x, notRepairUI.transform.position.y), 0.5f);
        // buildingScaleControl();
        isSelectImageControl();
        repairScaleControl();
    }

    public void OnClickForWantRepair()
    {
        isRepair = true;
        if (scaleForUIY < 0) {
            scaleForUIY = -scaleForUIY;
            scaleForUIX = -scaleForUIX;
        }
        //buildingScaleControl();
        notRepair.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
    }

    public void buildingScaleControl()
    {
        building.transform.DOScale(new Vector3(building.transform.localScale.x + scaleForBuilding, building.transform.localScale.y + scaleForBuilding), 0.5f);
        scaleForBuilding = -scaleForBuilding;
    }

    public void repairScaleControl()
    {
        Tween t = repair.transform.DOScale(new Vector3(repair.transform.localScale.x + scaleForUIX, repair.transform.localScale.y + scaleForUIY), 0.5f);
        building.enabled = false;
        t.OnComplete(
            () =>
            {
                building.enabled = true;
            }
        );
        scaleForUIY = -scaleForUIY;
        scaleForUIX = -scaleForUIX;
    }

    public void notRepairScaleControl()
    {
        notRepairUI.transform.DOMove(new Vector3(center.transform.position.x, notRepairUI.transform.position.y), 0.5f);
    }

    public void isSelectImageControl()
    {
        isSelect = !isSelect;
        if (isSelect)
        {
            gameObject.GetComponent<Image>().sprite = selectImage;
        }else
        {
            gameObject.GetComponent<Image>().sprite = unSelectImage;
        }
    }




    public void OnClickForBuilding()
    {
        //buildingScaleControl();
        if (!isRepair)
        {
            isSelectImageControl();
            notRepairScaleControl();
            //notRepair.transform.DOScale(new Vector3(notRepair.transform.localScale.x+scaleForUIY, notRepair.transform.localScale.x+scaleForUIY), 0.5f);
            //scaleForUIY = -scaleForUIY;
        }
        else
        {
            //buildingScaleControl();
            isSelectImageControl();
            repairScaleControl();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
