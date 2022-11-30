using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    add3 =1,
    x3 = 2,
    wallbot = 3,
    redpong =4,
}
public class UiShopPopup : MonoBehaviour
{
    // Start is called before the first frame update
    public Button HomeBtn;
    public Animator animator;
    public Button SettingBtn;
    public UIShopElement[] ShopElements;
    private void OnValidate()
    {
        if(ShopElements == null || ShopElements.Length == 0)
        {
            ShopElements = GetComponentsInChildren<UIShopElement>();
      
        }
    }
    private void SetData()
    {
        for(int i =0; i < ShopElements.Length; i++)
        {
            ShopElements[i].SetData(i);
        }
    }
    private void Awake()
    {
  
        SetData();
    }

    // Update is called once per frame

}
