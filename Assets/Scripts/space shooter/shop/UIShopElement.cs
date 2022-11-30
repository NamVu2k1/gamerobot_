using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopElement : MonoBehaviour
{
    // Start is called before the first frame update

    public int id;
    public int cost;
    public Text constTxt;
    public Text amountItem;
    public Button purchaseBtn;

    private void Awake()
    {
        


        purchaseBtn.onClick.AddListener(Onpurchase);
        var Sprite = gameObject.transform.GetChild(0).GetComponent<Image>();
        Sprite.sprite = Resources.Load<Sprite>($"Textures/{gameObject.name}");

    }
    public void SetData(int id)
    {
        this.id = id;
           
        UpdateView();
    }
    void UpdateView()
    {
        amountItem.text ="x" +  DataPlayer.GetItem(id).ToString();
        constTxt.text = cost.ToString();
      
       
    }
    void Onpurchase()
    {
       
        if(cost <= DataPlayer.GetCoin())
        {
            soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.buy);
            DataPlayer.SetCoin(-cost);
            DataPlayer.SetItem(id, 1);
            UpdateView();
        }


    }
}
