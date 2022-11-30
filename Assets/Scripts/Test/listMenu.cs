using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public string Anh;
    public string Ten;
}

public class listMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btnDan;
    public ScrollRect ScrollMenu;
    private Object[] mangAnh;

    void Start()
    {
        List<Item> myList = new List<Item>();
        Item _item;
        _item = new Item();
        _item.Anh = "1";
        _item.Ten = "Dan loai 1";
        myList.Add(_item);

        _item = new Item();
        _item.Anh = "2";
        _item.Ten = "Dan loai 2";
        myList.Add(_item);

        mangAnh = Resources.LoadAll("Textures", typeof(Texture2D));
        GameObject _newBtnDan;
        Texture2D _anhTimThay = null;

        foreach(Item pt in myList)
        {
            _newBtnDan = Instantiate(btnDan, ScrollMenu.transform.GetChild(0).GetChild(0).transform, true);
            _newBtnDan.SetActive(true);
            _newBtnDan.transform.GetChild(0).GetComponent<Text>().text = pt.Ten;
            Debug.Log(mangAnh.Length);

            for (int i= 0 ; i < mangAnh.Length; i++ )
            {
                Debug.Log("Ten Anh:" + mangAnh[i].name);
                Debug.Log("pt:" + pt.Ten);
                if(mangAnh[i].name == pt.Anh)
                {
                    _anhTimThay = mangAnh[i] as Texture2D;
                    Rect rec = new Rect(0, 0, _anhTimThay.width, _anhTimThay.height);
                    Debug.Log("_newBtnDan.Tranform.Getchild(1):" + _newBtnDan.transform.GetChild(1).name);
                    _newBtnDan.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(_anhTimThay, rec, new Vector2(0.5f, 0.5f), 100);
                    break;
                }
               
                }
            }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
