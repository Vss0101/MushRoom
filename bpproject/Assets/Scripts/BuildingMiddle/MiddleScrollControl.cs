using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MiddleScrollControl : MonoBehaviour
{
    public Button move;
    public GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        move.onClick.AddListener(delegate () { OnClickMove(); });
    }

    public void OnClickMove(){
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x,gameObject.transform.position.y-(move.transform.position.y-center.transform.position.y)),0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
