using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPanel : MonoBehaviour
{

    public Button down;
    public GameObject switchBackround;
    public GameObject nextPanel;
    public GameObject thisPanel;
    // Start is called before the first frame update
    void Start()
    {
        down.onClick.AddListener(delegate () { OnClick(); });
    }


    public void OnClick()
    {
        switchBackround.SetActive(true);
        switchBackround.GetComponent<Animator>().Play("FadeOut");
        Invoke("ReverseActive", 2f);
        Invoke("SwitchBack", 1f);
    }

    public void SwitchBack()
    {
        thisPanel.SetActive(false);
        nextPanel.SetActive(true);
        
    }

    public void ReverseActive()
    {
        switchBackround.SetActive(false);
        //gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
