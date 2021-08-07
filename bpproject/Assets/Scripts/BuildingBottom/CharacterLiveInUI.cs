using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class CharacterLiveInUI : MonoBehaviour
{
    public Button ok;
    public Button cancel;
    public Image character1;
    public Image character2;
    public Image character3;
    public Vector3 oldScale;
    public Vector3 newScale;


    // Start is called before the first frame update
    void Start()
    {
        oldScale = new Vector3(character1.transform.localScale.x, character1.transform.localScale.y,character1.transform.localScale.z);
        newScale = new Vector3(character1.transform.localScale.x+0.3f, character1.transform.localScale.y+0.3f, character1.transform.localScale.z);
        ok.onClick.AddListener(delegate () { OnClickOK(); });
        cancel.onClick.AddListener(delegate () { OnClickCancel(); });
        character1.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC1(); });
        character2.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC2(); });
        character3.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC3(); });
    }

    public void OnClickSelectC1()
    {
        AllScaleGoBack();
        character1.transform.DOScale(newScale,0.5f);
    }
    public void OnClickSelectC2()
    {
        AllScaleGoBack();
        character2.transform.DOScale(newScale, 0.5f);
    }
    public void OnClickSelectC3()
    {
        AllScaleGoBack();
        character3.transform.DOScale(newScale, 0.5f);
    }

    public void AllScaleGoBack()
    {
        character1.transform.DOScale(oldScale, 0.5f);
        character2.transform.DOScale(oldScale, 0.5f);
        character3.transform.DOScale(oldScale, 0.5f);
    }


    public void OnClickCancel()
    {
        AllScaleGoBack();
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x + 800, gameObject.transform.position.y), 0.5f);
    }

    public void OnClickOK()
    {
        AllScaleGoBack();
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x + 800, gameObject.transform.position.y), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick(BaseEventData data)
    {

    }
}
