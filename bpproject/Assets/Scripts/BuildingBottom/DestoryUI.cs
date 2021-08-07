using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DestoryUI : MonoBehaviour
{
    public Button ok;
    public Button cancel;
    // Start is called before the first frame update
    void Start()
    {
        ok.onClick.AddListener(delegate () { OnClickOK(); });
        cancel.onClick.AddListener(delegate () { OnClickCancel(); });

    }

    public void OnClickCancel()
    {
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x + 800, gameObject.transform.position.y), 0.5f);
    }

    public void OnClickOK()
    {
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x + 800, gameObject.transform.position.y), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
