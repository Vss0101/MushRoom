using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkill : MonoBehaviour
{
    public Button goBack;
    // Start is called before the first frame update
    void Start()
    {
        goBack.onClick.AddListener(delegate () { OnClickGoBack(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickGoBack()
    {
        gameObject.SetActive(false);
    }
}
