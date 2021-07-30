using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    public GameObject panel;
    public GameObject LoadingP;
        //= new GameObject();
    public Button button;
    // Start is called before the first frame update
    void Awake()
    {
        button.onClick.AddListener(delegate() { OnClick(); });
    }

    public void OnClick()
    {
        panel.SetActive(false);
        LoadingP.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
