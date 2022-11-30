using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerController : MonoBehaviour
{
    Vector3 MousePos;
    Vector2 MousePosDrag;
    public GameObject pau, win;

    // Start is called before the first frame update
    bool mouseButtonup = true;
    bool onMouse = false;
    void Start()
    {
        int levelScalePlayer = DataPlayer.GetlevelScalePlayer();
        gameObject.transform.localScale = new Vector3(0.75f * (1f+levelScalePlayer * 0.05f), 0.1f, 0);
        Debug.Log("in PC");
    }

    // Update is called once per frame
    void Update()
    {
        //bool set = pau.activeSelf;

        //if (Input.touchCount > 0)
        //{
        //    if (Input.touchCount == 1)
        //    {
        //        if (Input.GetTouch(0).phase == TouchPhase.Began)
        //        {
        //            if (EventSystem.current.IsPointerOverGameObject(0))
        //            {

        //                return;
        //            }
        //            onMouse = true;

        //            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        //        }
        //        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //        {
        //            if (EventSystem.current.IsPointerOverGameObject(0))
        //            {
        //                return;
        //            }
        //            MousePosDrag = Camera.main.ScreenToWorldPoint(Input.mousePosition) - MousePos;

        //            gameObject.transform.position = new Vector3(MousePosDrag.x, transform.position.y, 0);
        //            if (gameObject.transform.position.x < -2.3f)
        //            {
        //                gameObject.transform.position = new Vector3(-2.29f, transform.position.y, 0);
        //            }
        //            else if (gameObject.transform.position.x > 2.3f)
        //            {
        //                gameObject.transform.position = new Vector3(2.29f, transform.position.y, 0);
        //            }
        //        }
        //        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //        {
        //            if (mouseButtonup == true)
        //            {

        //                bulletparticle.Instance.DoEmitPlay();
        //                sliderUI.Instance.realtime();
        //                mouseButtonup = false;

        //            }
        //        }
        //    }

        //}




        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject(0))
            {

                return;
            }
            onMouse = true;

            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;


        }
        if (Input.GetMouseButton(0) && onMouse == true)
        {

            if (EventSystem.current.IsPointerOverGameObject(0))
            {
                return;
            }
            MousePosDrag = Camera.main.ScreenToWorldPoint(Input.mousePosition) - MousePos;

            gameObject.transform.position = new Vector3(MousePosDrag.x, transform.position.y, 0);
            if (gameObject.transform.position.x < -2.3f)
            {
                gameObject.transform.position = new Vector3(-2.29f, transform.position.y, 0);
            }
            else if (gameObject.transform.position.x > 2.3f)
            {
                gameObject.transform.position = new Vector3(2.29f, transform.position.y, 0);
            }


        }
        if (Input.GetMouseButtonUp(0))
        {
            onMouse = false;
            if (mouseButtonup == true)
            {

                bulletparticle.Instance.DoEmitPlay();
                sliderUI.Instance.realtime();
                mouseButtonup = false;

            }
        }

    }



}


