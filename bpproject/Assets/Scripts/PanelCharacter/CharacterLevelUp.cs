using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterLevelUp : MonoBehaviour
{
    public Slider slider;
    public int level;
    public GameObject levelUp;
    public Text text;
    public Text levelText;
    public Message tips;
    public Text globalEXP;
    public GameObject resource;
    public GameObject EXPImage;
    public bool isRun;
    public Text EXPCount;
    public bool isDown;


    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "lv.1";
        level = 1;
        levelUp.GetComponent<Button>().onClick.AddListener(delegate () { OnClickLevelUp(); });
        EXPCount.text = globalEXP.text;
        isDown = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = slider.value + "/" + level * 500;
        if(int.Parse(globalEXP.text) !=int.Parse( EXPCount.text))
        {
            Dotween();
        }
    }

    public void OnClickLevelUp()
    {
        if (int.Parse(globalEXP.text) >= level * 500)
        {
            InvokeRepeating("ShowConsumeResource", 0f, 0.1f);
            slider.maxValue = level * 500;
            slider.value = 0;
            Invoke("CancelRun", 1.2f);
            globalEXP.text = (int.Parse(globalEXP.text) - level * 500).ToString();
            Invoke("LevelUp", 1.2f);
            levelUp.GetComponent<Button>().enabled = false;
            
        }
        else
        {
            tips.GetMessage("EXP Not Enough");
        }
    }

    public void LevelUp()
    {
        Tween t = DOTween.To(() => slider.value, x => slider.value = x, level * 500 - 1, 2f);
        t.OnComplete(
            () =>
            {
                level++;
                slider.value = 0;
                levelText.text = "lv." + level;
                levelUp.GetComponent<Button>().enabled = true;
            }
        );
    }

    public void Dotween()
    {
        if (isDown)
        {
            isDown = false;
            Tween t1 = DOTween.To(value => { EXPCount.text = Mathf.Floor(value).ToString(); }, startValue: int.Parse(EXPCount.text), endValue: int.Parse(globalEXP.text), duration: 2f);
            t1.OnComplete(
               () =>
               {
                   isDown = true;
                   EXPCount.text = globalEXP.text;
               }
           );
        }
    }

    public void CancelRun()
    {
        CancelInvoke("ShowConsumeResource");
    }

    public void ShowConsumeResource()
    {
            resource.GetComponent<GetResource>().changePicture(8);
            GameObject go = GameObject.Instantiate(resource, new Vector3(EXPImage.transform.position.x, EXPImage.transform.position.y), new Quaternion());

            go.transform.SetParent(EXPImage.transform);
            Vector3[] ctrlPoints = new Vector3[3];

            ctrlPoints[0] = go.transform.position;
            ctrlPoints[1] = go.transform.position;
            ctrlPoints[2] = text.transform.position;

            go.GetComponent<GetResource>().getIsStart(true, ctrlPoints);

    }


}
