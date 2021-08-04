using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopUI : MonoBehaviour
{
    public Button test;
    public GameObject image;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        test.onClick.AddListener(delegate () { OnClick(); });
    }

    public void OnClick()
    {
        flag = !flag;
        if (flag)
        {
            //image.SetActive(true);
            image.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        }
        else
        {
            //image.SetActive();
            image.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
