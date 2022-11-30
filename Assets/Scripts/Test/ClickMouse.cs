using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMouse : MonoBehaviour
{
    float StartPosX;
    float StartPosY;
    private bool isBeingHeld= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBeingHeld)
        {
            

        }
    }
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            StartPosX = mousePos.x - this.transform.localPosition.x;
            StartPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHeld = true;
            
        }
    }
    public void OnMouseUp()
    {
        isBeingHeld = false;

    }
    public void OnMouseDrag()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.transform.localPosition = new Vector3(mousePos.x - StartPosX, mousePos.y - StartPosY, -1);
        }
    }
    public void OnMouseEnter()
    {
        Debug.Log("Enter");
   
    }
}
