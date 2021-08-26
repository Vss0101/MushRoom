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
    public GameObject position;

    public void GetMessage(string str){
        message = str;
        text.text = message;
        Image.transform.DOMove(new Vector3(gameObject.transform.position.x, position.transform.position.y, 0), 0.8f); 
        Invoke("GoBack",2);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBack(){
        Image.transform.DOMove(new Vector3(gameObject.transform.position.x, Image.transform.position.y + 300, 0), 0.8f);
    }


}
