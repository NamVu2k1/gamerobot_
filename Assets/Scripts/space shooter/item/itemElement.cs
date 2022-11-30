using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class itemElement : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public Text amountItem_txt;
    public Button item_btn;
    private void Awake()
    {



        item_btn.onClick.AddListener(UsedItem);
        var Sprite = gameObject.GetComponent<Image>();
        Sprite.sprite = Resources.Load<Sprite>($"Textures/{gameObject.name}");

    }
    public void SetData(int id)
    {
        this.id = id;

        UpdateView();
    }
    void UpdateView()
    {
        amountItem_txt.text = "x" + DataPlayer.GetItem(id).ToString();
       
    }
    void UsedItem()
    {
        if(DataPlayer.GetItem(id) > 0)
        {
            DataPlayer.SetItem(id, -1);
            UpdateView();
        }
    }
    

    // Update is called once per frame
   
}
