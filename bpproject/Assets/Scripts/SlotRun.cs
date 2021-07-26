using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlotRun : MonoBehaviour
{
    public Image pointASub;
    public Image pointBSub;
    public Image pointCSub;
   // public GameObject centerObject;
    //public Vector2 centerPosition;
    public float speed;
    public Button run;
    public bool stop;
   // public GameObject pointCForWater;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public Image pointCForWater;


    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        //centerPosition = centerObject.transform.position;
        speed = 30;
        run.onClick.AddListener(delegate () { OnClick(); });
    }

    public void OnClick()
    {
        speed = 200;
        //stop = true;
        // stop = true;
        // SlotStop();
        // Invoke("ReverseStopFlag", 3f);
        pointC.transform.DORotate(new Vector3(0, 0, 135 +360*2),10,RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        
        pointB.transform.DORotate(new Vector3(0, 0, 135), 2).SetEase(Ease.OutQuad);
        pointA.transform.DORotate(new Vector3(0, 0, 135), 2).SetEase(Ease.OutQuad);

    }

    public void ReverseStopFlag()
    {
        stop = !stop;
    }

    public void SlotStop()
    {
        float position = pointCForWater.rectTransform.position.y - pointCSub.rectTransform.position.y;
        Debug.Log(position);
        if(position <= 200f) {
            
        }

    }

    // Update is called once per frame
    void Update()
    {

        //pointA.transform.Rotate( Vector3.forward, speed * Time.deltaTime);
        //pointB.transform.Rotate( Vector3.forward, speed * Time.deltaTime);
        // pointC.transform.Rotate( Vector3.forward, speed * Time.deltaTime);



        if (stop)
        {
            SlotStop();
        }
    }
}
