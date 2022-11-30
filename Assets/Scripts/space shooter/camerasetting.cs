using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class camerasetting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SpriteRenderer spriteRenderer;
    float aspect_ = 0.4621951f;
    public Transform panel_top;

    private void Start()
    {
        float heightseen = mainCamera.pixelHeight;

        float aspect_in = mainCamera.aspect;
        if(mainCamera.orthographicSize * aspect_ / aspect_in <4.4)
        {
            mainCamera.orthographicSize = 4.4f;
        }else
        {
            mainCamera.orthographicSize = mainCamera.orthographicSize * aspect_ / aspect_in;
        }
        
        var panel_top_to_ScreenPoin = mainCamera.WorldToScreenPoint(panel_top.transform.position);

        //Debug.Log(panel_top_to_ScreenPoin + " "+ mainCamera.WorldToScreenPoint(transform.position));

        Vector3 newPosCamera = mainCamera.WorldToScreenPoint(transform.position) - new Vector3(0, heightseen - panel_top_to_ScreenPoin.y, 0);
        mainCamera.transform.position = mainCamera.ScreenToWorldPoint(newPosCamera);

    }
    void Update()
    {

    }
}