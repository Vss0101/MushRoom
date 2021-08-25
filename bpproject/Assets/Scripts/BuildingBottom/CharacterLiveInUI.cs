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
    public Button right;
    public Button left;
    public GameObject content;
    private int selectCharacter;
    public CanvasGroup rightCanvas;
    public CanvasGroup leftCanvas;


    // Start is called before the first frame update
    void Start()
    {
        selectCharacter = 1;
        ok.onClick.AddListener(delegate () { OnClickOK(); });
        cancel.onClick.AddListener(delegate () { OnClickCancel(); });
        character1.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC1(); });
        character2.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC2(); });
        character3.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC3(); });
        right.GetComponent<Button>().onClick.AddListener(delegate () { OnClickGoRight(); });
        left.GetComponent<Button>().onClick.AddListener(delegate () { OnClickGoLeft(); });
        rightCanvas = right.GetComponent<CanvasGroup>();
        leftCanvas = left.GetComponent<CanvasGroup>();

        
    }

    public void OnClickSelectC1()
    {

    }
    public void OnClickSelectC2()
    {

    }
    public void OnClickSelectC3()
    {

    }

    public void OnClickGoRight()
    {
        content.transform.DOMove(new Vector3(content.transform.position.x - 465, content.transform.position.y), 0.5f);
        selectCharacter++;
    
    }

    public void OnClickGoLeft()
    {
        content.transform.DOMove(new Vector3(content.transform.position.x + 465, content.transform.position.y), 0.5f);
        selectCharacter--;
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
       
        if(selectCharacter == 1)
        {
            leftCanvas.alpha = 0.5f;
            left.enabled = false;
        }else if (selectCharacter == 4)
        {
            rightCanvas.alpha = 0.5f;
            right.enabled = false;
        }
        else
        {
            leftCanvas.alpha = 1f;
            left.enabled = true;
            rightCanvas.alpha = 1f;
            right.enabled = true;
        }

    }

    public void OnClick(BaseEventData data)
    {

    }
}
