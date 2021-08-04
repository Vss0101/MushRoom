using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDown : MonoBehaviour
{
    public Button down;
    public GameObject switchBackround;
    public GameObject middlePanel;
    // Start is called before the first frame update
    void Start()
    {
        down.onClick.AddListener(delegate () { OnClick(); });
    }

    public void OnClick()
    {
        switchBackround.SetActive(true);
        switchBackround.GetComponent<Animator>().Play("FadeOut");
        Invoke("ReverseActive",2f);
        Invoke("SwitchPanel", 1f);
    }

    public void SwitchPanel()
    {
        middlePanel.SetActive(true);
        gameObject.SetActive(false);
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
