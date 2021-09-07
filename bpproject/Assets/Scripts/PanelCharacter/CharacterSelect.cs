using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Image characterSelect;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;

    public GameObject U1;
    public GameObject U2;
    public GameObject U3;
    public GameObject U4;

    // Start is called before the first frame update
    void Start()
    {
        c1.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC1(); });
        c2.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC2(); });
        c3.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC3(); });
        c4.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelectC4(); });
        U1.SetActive(true);
    }

    public void OnClickSelectC1()
    {
        characterSelect.sprite = s1;
        Reset();
        U1.SetActive(true);
        
    }
    public void OnClickSelectC2()
    {
        characterSelect.sprite = s2;
        Reset();
        U2.SetActive(true);
    }
    public void OnClickSelectC3()
    {
        characterSelect.sprite = s3;
        Reset();
        U3.SetActive(true);
    }
    public void OnClickSelectC4()
    {
        characterSelect.sprite = s4;
        Reset();
        U4.SetActive(true);
    }

    public void Reset()
    {
        U1.SetActive(false);
        U2.SetActive(false);
        U3.SetActive(false);
        U4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
