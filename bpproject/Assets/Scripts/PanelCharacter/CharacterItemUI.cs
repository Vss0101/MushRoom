using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterItemUI : MonoBehaviour
{
    public GameObject characterItemPanel;
    public GameObject tablePanelForCharacter;



    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<Button>().onClick.AddListener(delegate () { OnClickSelect(); });
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSelect()
    {
        tablePanelForCharacter.SetActive(true);
        characterItemPanel.SetActive(true);
    }


}
