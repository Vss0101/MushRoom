using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HighLightControl : MonoBehaviour
{
    public bool run;
    private CanvasGroup moonCanvasGroup;
    void Start()
    {
        moonCanvasGroup = GetComponent<CanvasGroup>();
        run = true;
        moonCanvasGroup.alpha = 0;
    }


    // Update is called once per frame
    void Update()
    {

       if (run)
        {
            run = false;
            Tween t = DOTween.To(() => moonCanvasGroup.alpha, x => moonCanvasGroup.alpha = x, 0.6f, 0.5f);
            t.OnComplete(
                () =>
                {
                   Tween z = DOTween.To(() => moonCanvasGroup.alpha, x => moonCanvasGroup.alpha = x, 0f, 0.5f);
                    z.OnComplete(
               () =>
               {
                   gameObject.SetActive(false);
                   run = true;
               }
           );
                }
            );
        }

    }
}
