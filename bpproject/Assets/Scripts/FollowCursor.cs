using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    private TrailRenderer trail;


    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            trail.startColor = Color.green;
            trail.endWidth = 3;

        }
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;

    }
}
