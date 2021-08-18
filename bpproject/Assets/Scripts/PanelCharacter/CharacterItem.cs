using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterItem : MonoBehaviour
{
    public Button goBack;
    public GameObject tablePanelForCharacter;
    public GameObject tableBarForHome;
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
        tablePanelForCharacter.SetActive(false);
        gameObject.SetActive(false);
        tableBarForHome.SetActive(true);
    }
}
