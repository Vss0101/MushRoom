using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GetResource : MonoBehaviour
{
    // public GameObject resource;
    // public GameObject resourceUI;
    // Start is called before the first frame update
    void Start()
    {
        
        //TweenUtils.BezierTo
        Tween t = gameObject.transform.DOMove(new Vector3(0,0,0),3).SetEase(Ease.InSine);

        t.OnComplete(
            () =>
            {
                GameObject.Destroy(gameObject);
            }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
