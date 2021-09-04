using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CalTreeHeight : MonoBehaviour
{
    public Text globalUnlockData;
    public Text myTreeHeight;
    public Text myFriendTreeHeight;

    public string subTreeHeight;
    public string subFriendTreeHeight;

    private bool isDown;
    // Start is called before the first frame update
    void Start()
    {
        subTreeHeight = myTreeHeight.text.Substring(0, myTreeHeight.text.Length - 1);
        subFriendTreeHeight = myFriendTreeHeight.text.Substring(0, myFriendTreeHeight.text.Length - 1);
        isDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            if (int.Parse(subTreeHeight) != int.Parse(globalUnlockData.text) * 500)
            {
                DoTween();
            }
        }
        myTreeHeight.text = subTreeHeight + "M";
        myFriendTreeHeight.text = subFriendTreeHeight + "M";
    }

    void DoTween()
    {
        isDown = false;
         DOTween.To(value => { subTreeHeight = Mathf.Floor(value).ToString(); }, startValue: int.Parse(subTreeHeight), endValue: int.Parse(globalUnlockData.text)*500, duration: 1f);
        Tween t = DOTween.To(value => { subFriendTreeHeight = Mathf.Floor(value).ToString(); }, startValue: int.Parse(subFriendTreeHeight), endValue: 5500 - int.Parse(globalUnlockData.text) * 500, duration: 1f);
        t.OnComplete(
            () =>
            {
                isDown = true;
                subTreeHeight = myTreeHeight.text.Substring(0, myTreeHeight.text.Length - 1);
                subFriendTreeHeight= myFriendTreeHeight.text.Substring(0, myFriendTreeHeight.text.Length - 1);

            }
        );
    }
}
