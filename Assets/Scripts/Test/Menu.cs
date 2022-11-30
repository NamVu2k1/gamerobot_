using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public class item
    {
        public string Anh;
        public string Ten;
    }
    public GameObject bbtnDan;
    public ScrollRect ScrollMenu;
    private Object[] mangAnh;
    void Start()
    {
        List<item> lstDanhSachs = new List<item>();
        item _item;
        _item = new item();
        _item.Anh = "1";
        _item.Ten = "Dan loai 1";
        lstDanhSachs.Add(_item);

        _item = new item();
        _item.Anh = "2";
        _item.Ten = "Dan loai 2";
        lstDanhSachs.Add(_item);

        mangAnh = Resources.LoadAll("Textures", typeof(Texture2D));

        GameObject _newBtnDan;
        Texture2D _AnhTimThay = null ;

        foreach(item pt in lstDanhSachs)
        {
            _newBtnDan = Instantiate(bbtnDan, ScrollMenu.transform.GetChild(0).GetChild(0).transform, true) as GameObject;
            _newBtnDan.SetActive(true);
            _newBtnDan.transform.GetChild(0).GetComponent<Text>().text = pt.Ten;

            for (int i = 0; i < mangAnh.Length; i++)
            {
                Debug.Log("Ten Anh:" + mangAnh[i].name);
                Debug.Log("PT:" + pt.Anh);

                if (mangAnh[i].name == pt.Anh)
                {
                    _AnhTimThay = mangAnh[i] as Texture2D;
                    Rect rec = new Rect(0, 0, _AnhTimThay.width, _AnhTimThay.height);
                    Debug.Log("_newBtnDan.transform.GetChild(1):" + _newBtnDan.transform.GetChild(1).name);
                    _newBtnDan.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(_AnhTimThay, rec, new Vector2(0.5f, 0.5f), 100);

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
