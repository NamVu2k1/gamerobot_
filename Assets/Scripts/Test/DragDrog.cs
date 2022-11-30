using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragDrog : MonoBehaviour , IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public Image viTriDung;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;
    private float StartPosX;
    private float StartPosY;
    private float PosZ;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        StartPosX = rectTransform.anchoredPosition.x;
        StartPosY = rectTransform.anchoredPosition.y;
        Debug.Log(StartPosX + " " + StartPosY);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("nhap chuat");    
        //rectTransform = transform.GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("bat dau keo" + eventData.pointerEnter.name);
    }
    public void OnDrag(PointerEventData evenData)
    {
        Debug.Log("dang keo ");
        rectTransform.anchoredPosition += evenData.delta/ canvas.scaleFactor;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(rectTransform.anchoredPosition != viTriDung.rectTransform.anchoredPosition)
        {
            rectTransform.anchoredPosition = new Vector2(StartPosX, StartPosY);
            Debug.Log("1");
         
        }
        else if (rectTransform.anchoredPosition == viTriDung.rectTransform.anchoredPosition)
        {
            this.GetComponent<Image>().raycastTarget = false;
            Debug.Log("2");
        }
        canvasGroup.blocksRaycasts = true;
        Debug.Log("ket thuc");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
