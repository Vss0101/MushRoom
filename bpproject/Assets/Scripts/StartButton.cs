using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    public GameObject panel = new GameObject();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
