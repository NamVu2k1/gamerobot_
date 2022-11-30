using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
    

public class drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private RectTransform rect;
    public void OnPointerDown(PointerEventData eventData)
    {
        rect = transform.GetComponent<RectTransform>(); 
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
