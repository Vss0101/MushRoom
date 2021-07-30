using System;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
namespace ForeverNine.MagicCoast {

public class TweenUtils
{
    /// <summary>
    /// tweenTo一个区间值
    /// </summary>
    /// <param name="time"></param>
    /// <param name="startValue"></param>
    /// <param name="endValue"></param>
    /// <param name="onUpdate"></param>
    /// <param name="onComplete"></param>
    /// <param name="delay"></param>
    /// <param name="ease"></param>
    /// <returns></returns>
    public static Tween TweenTo(float time, float startValue, float endValue, Action<float> onUpdate, Action onComplete, float delay = 0, Ease ease = Ease.Linear)
    {
        Tween tween = DOTween.To((x) => { onUpdate?.Invoke(x); }, startValue, endValue, time)
            .SetDelay(delay)
            .SetEase(ease)
            .OnComplete(() => {
                onComplete?.Invoke();
            });
        return tween;
    }
    /// <summary>
    /// 贝塞尔曲线
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="ctrlPoints"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static Tween BezierTo(Transform trans, Vector3[] ctrlPoints, float time)
    {
        DOSetter<float> setter = x =>
        {
            if (ctrlPoints.Length == 3)
            {
                trans.localPosition = Bezier.GetPoint(ctrlPoints[0], ctrlPoints[1], ctrlPoints[2], x);
            }
            else if (ctrlPoints.Length == 4)
            {
                trans.localPosition = Bezier.GetPoint(ctrlPoints[0], ctrlPoints[1], ctrlPoints[2], ctrlPoints[3], x);
            }
            else if (ctrlPoints.Length == 5)
            {
                trans.localPosition = Bezier.GetPoint(ctrlPoints[0], ctrlPoints[1], ctrlPoints[2], ctrlPoints[3], ctrlPoints[4], x);
            }
        };
        Tweener tween = DOTween.To(setter, 0, 1, time);
        return tween;
    }

    public static Tween BezierToByWorldPosition(Transform trans, Vector3[] ctrlPoints, float time)
    {
        DOSetter<float> setter = x =>
        {
            if (ctrlPoints.Length == 3)
            {
                trans.position = Bezier.GetPoint(ctrlPoints[0], ctrlPoints[1], ctrlPoints[2], x);
            }
            else if (ctrlPoints.Length == 4)
            {
                trans.position = Bezier.GetPoint(ctrlPoints[0], ctrlPoints[1], ctrlPoints[2], ctrlPoints[3], x);
            }
            else if (ctrlPoints.Length == 5)
            {
                trans.position = Bezier.GetPoint(ctrlPoints[0], ctrlPoints[1], ctrlPoints[2], ctrlPoints[3], ctrlPoints[4], x);
            }
        };
        Tweener tween = DOTween.To(setter, 0, 1, time);
        return tween;
    }
}
}
