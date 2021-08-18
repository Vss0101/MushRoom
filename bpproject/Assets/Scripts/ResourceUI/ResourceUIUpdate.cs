using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResourceUIUpdate : MonoBehaviour
{
    public Text globalLand;
    public Text globalWater;
    public Text globalWind;
    public Text globalFire;

    public Text landUI;
    public Text waterUI;
    public Text windUI;
    public Text fireUI;

    private bool isDown;
    // Start is called before the first frame update
    void Start()
    {
        landUI.text = globalLand.text;
        waterUI.text = globalWater.text;
        windUI.text = globalWind.text;
        fireUI.text = globalFire.text;
        isDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDown)
        {
            if (int.Parse(landUI.text) != int.Parse(globalLand.text))
            {
                DoTween();
            }
            else if (int.Parse(waterUI.text) != int.Parse(globalWater.text))
            {
                DoTween();
            }
            else if (int.Parse(fireUI.text) != int.Parse(globalFire.text))
            {
                DoTween();
            }
            else if (int.Parse(windUI.text) != int.Parse(globalWind.text))
            {
                DoTween();
            }

        }
    }

    public void DoTween()
    {
        isDown = false;
        Tween t = DOTween.To(value => { landUI.text = Mathf.Floor(value).ToString(); }, startValue: int.Parse(landUI.text), endValue: int.Parse(globalLand.text), duration: 1f);
        t.OnComplete(
            () =>
            {
                isDown = true;
                landUI.text = globalLand.text;
                waterUI.text = globalWater.text;
                windUI.text = globalWind.text;
                fireUI.text = globalFire.text;
            }
        );
        DOTween.To(value => { windUI.text = Mathf.Floor(value).ToString(); }, startValue: int.Parse(windUI.text), endValue: int.Parse(globalWind.text), duration: 1f);
        DOTween.To(value => { fireUI.text = Mathf.Floor(value).ToString(); }, startValue: int.Parse(fireUI.text), endValue: int.Parse(globalFire.text), duration: 1f);
        DOTween.To(value => { waterUI.text = Mathf.Floor(value).ToString(); }, startValue: int.Parse(waterUI.text), endValue: int.Parse(globalWater.text), duration: 1f);

    }
}
