using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MiddleScrollControl : MonoBehaviour
{
    public Button move;
    public GameObject center;
    public GameObject scroll;
    // Start is called before the first frame update
    void Start()
    {
        move.onClick.AddListener(delegate () { OnClickMove(); });
    }

    public void OnClickMove(){
        scroll.transform.DOMove(new Vector3(scroll.transform.position.x,scroll.transform.position.y-(move.transform.position.y-center.transform.position.y)),0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
