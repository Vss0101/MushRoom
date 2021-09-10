using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class Message : MonoBehaviour
{
    public Text text;
    //显示消息内容
    public string message;
    public GameObject Image;
    public GameObject position;
    public bool isDown;

    public void GetMessage(string str){
        message = str;
        text.text = message;
        if (isDown)
        {
            isDown = false;
            Image.transform.DOMove(new Vector3(gameObject.transform.position.x, position.transform.position.y, 0), 0.8f);
            Invoke("GoBack",2f);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBack(){
        Tween t = Image.transform.DOMove(new Vector3(gameObject.transform.position.x, Image.transform.position.y + 200, 0), 0.8f);
        t.OnComplete(
          () =>
          {
              isDown = true;
          }
      );
    }


}
