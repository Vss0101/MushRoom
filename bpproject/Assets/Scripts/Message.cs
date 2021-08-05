using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Message : MonoBehaviour
{
    public Text text;
    //显示消息内容
    public string message;
    public GameObject Image;

    public void GetMessage(string str){
        message = str;
        text.text = message;
        Start();
        Invoke("GoBack",2);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(message!=""){
          Image.transform.DOLocalMove(new Vector3(0, 610, 0), 0.8f); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBack(){
        Image.transform.DOLocalMove(new Vector3(0, 720, 0), 0.8f);
    }


}
