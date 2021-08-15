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

    // Start is called before the first frame update
    void Start()
    {
        isUnlock = false;
        gameObject.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelect(); });
        unlock.onClick.AddListener(delegate () { OnClickUnlock(); });
        scale = 0.5f;
        scaleForPop = 3;
    }

    public void OnClickSelect()
    {
        if (int.Parse(globalUnlockData.GetComponent<Text>().text) != level)
        {

        }
        else if (!isUnlock)
        {
            popUI.transform.DOScale(new Vector3(popUI.transform.localScale.x+scaleForPop, popUI.transform.localScale.y+ scaleForPop), 0.5f);
            image.transform.DOScale(new Vector3(image.transform.localScale.x + scale, image.transform.localScale.y + scale), 0.5f);
            scale *= -1;
            scaleForPop *= -1;
        }
    }

    public void OnClickUnlock()
    {
        popUI.transform.DOScale(new Vector3(0, 0), 0.5f);
        isUnlock = true;
        image.sprite = unLockImage;
        globalUnlockData.GetComponent<Text>().text = (int.Parse(globalUnlockData.GetComponent<Text>().text )+1).ToString();
        if ((int.Parse(globalUnlockData.GetComponent<Text>().text)-1) % 3 == 0)
        {
            content.transform.DOMove(new Vector3(content.transform.position.x, content.transform.position.y - 1334),1f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
