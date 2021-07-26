using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowUI : MonoBehaviour
{
    public Button character;
    public Button setting;
    public Button up;

    // Start is called before the first frame update
    void Start()
    {
        
        up.onClick.AddListener(delegate () { OnClick(); });
    }

    public void OnClick()
    {
        Vector3 scale = up.transform.localScale;
        if (scale.x >= 1)
        {
            Forward();
        }
        else
        {
            Back();
        }
        scale.x *= -1;
        up.transform.localScale = scale;
        
    }

    public void Forward()
    {
        character.transform.DOMove(new Vector2(character.transform.position.x,300),1);
        setting.transform.DOMove(new Vector2(setting.transform.position.x, 250), 1);
    }

    public void Back()
    {
        character.transform.DOMove(new Vector2(character.transform.position.x, -300), 1);
        setting.transform.DOMove(new Vector2(setting.transform.position.x, -250), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
