using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class joystickControler : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject joystick;
    public GameObject joystickBG;
    public static Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    bool status;
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
        Debug.Log(joystickRadius);
    }
    public void PointerDown()
    {

     


        //status = Physics2D.OverlapCircle(Input.mousePosition, 300);
       
        if (status == false)
        {
            //joystick.transform.position = Input.GetTouch(0).position;   su dung khi cham vao man hinh lan dau
            joystick.transform.position = Input.mousePosition;
            joystickBG.transform.position = Input.mousePosition;
            joystickTouchPos = Input.mousePosition;
            Debug.Log(1);
        }


    }
    public void Drag(BaseEventData baseEventData)
    {
        if (status == false)
        {
            PointerEventData pointerEventData = baseEventData as PointerEventData;
            Vector2 dragPos = pointerEventData.position;
            //Debug.Log("dragPos:" + dragPos.x + " " + dragPos.y);
            joystickVec = (dragPos - joystickTouchPos).normalized;
            float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);
            //Debug.Log(joystickDist);
            if (joystickDist < joystickRadius)
            {
                joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
                //Debug.Log(":" + joystickVec * joystickDist);
            }
            else
            {
                joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
            }
 
        }


    }
    public void PointerUp()
    {

        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;

    }
}
