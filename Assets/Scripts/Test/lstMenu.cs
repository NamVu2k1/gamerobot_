using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item
{
    public string Ten;
    public string Anh;
}
public class lstMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btnDan;
    public ScrollRect ScrollMenu;
    private Object[] mangAnh;
    //
    public Button btnAdd;
    public Button btnRemove;
    public Image imgAnh;
    void Start()
    {
        int click = 0;

        List < item > myList = new List<item>();
        item _item;
        _item = new item();
        _item.Anh = "1";
        _item.Ten = "game 1";
        myList.Add(_item);

        _item = new item();
        _item.Anh = "2";
        _item.Ten = "game 2";
        myList.Add(_item);

        _item = new item();
        _item.Anh = "3";
        _item.Ten = "game 3";
        myList.Add(_item);

        _item = new item();
        _item.Anh = "4";
        _item.Ten = "game 4";
        myList.Add(_item);

        _item = new item();
        _item.Anh = "5";
        _item.Ten = "game 5";
        myList.Add(_item);



        mangAnh = Resources.LoadAll("Textures", typeof(Texture2D));
      
        Texture2D _anhTimThay = null;

        foreach(item pt in myList)
        {
            GameObject _newBtnDan;
            _newBtnDan = Instantiate(btnDan, ScrollMenu.transform.GetChild(0).GetChild(0).transform, true);
            _newBtnDan.SetActive(true);
            _newBtnDan.transform.GetChild(0).GetComponent<Text>().text = pt.Ten;
            _newBtnDan.GetComponent<Button>().onClick.AddListener(delegate {
                
                imgAnh.sprite = _newBtnDan.transform.GetChild(1).GetComponent<Image>().sprite;        
            });
            for(int i = 0; i < mangAnh.Length; i++)
            {
                if(mangAnh[i].name == pt.Anh)
                {
                    _anhTimThay = mangAnh[i] as Texture2D;
                    Rect rec = new Rect(0, 0, _anhTimThay.width, _anhTimThay.height);
                    _newBtnDan.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(_anhTimThay, rec, new Vector2(0.5f, 0.5f), 100);
                    break;
                }
            }
        }
        
        //nut xoa
        btnRemove.GetComponent<Button>().onClick.AddListener(delegate {

            click -= 1;
          //  myList.Remove(_item);
            for (int i = ScrollMenu.transform.GetChild(0).GetChild(0).childCount - 1; i > 0; i--)
            {
                Destroy(ScrollMenu.transform.GetChild(0).GetChild(0).GetChild(i).gameObject);
                break;
            }
            Debug.Log(click);
        });


        // nut them
        btnAdd.GetComponent<Button>().onClick.AddListener(delegate {
            //ep gan ten cho item va them vao list
            //click += 1;
            //_item = new item();
            //_item.Anh = (int.Parse("2") + click).ToString();
            //_item.Ten = "game " + _item.Anh;
            //myList.Add(_item);
            int cs = Random.Range(0,mangAnh.Length);

            GameObject _newBtnDan;
            _newBtnDan = Instantiate(btnDan, ScrollMenu.transform.GetChild(0).GetChild(0).transform, true);
            _newBtnDan.SetActive(true);
            _newBtnDan.transform.GetChild(0).GetComponent<Text>().text = myList[cs].Ten;
            _newBtnDan.GetComponent<Button>().onClick.AddListener(delegate {

                imgAnh.sprite = _newBtnDan.transform.GetChild(1).GetComponent<Image>().sprite;


            });
            Debug.Log(mangAnh.Length + "-->cs:" + cs) ;
            //for (int i = 0; i < mangAnh.Length; i++)
            //{
              //  if (mangAnh[i].name == myList[1 + click].Anh)
                //{
                    _anhTimThay = mangAnh[cs] as Texture2D;
                    Rect rec = new Rect(0, 0, _anhTimThay.width, _anhTimThay.height);
                    _newBtnDan.transform.GetChild(1).GetComponent<Image>().sprite = Sprite.Create(_anhTimThay, rec, new Vector2(0.5f, 0.5f), 100);
                    
                  //  break;
                //}
            //}

          //  Debug.Log(click);


        });
       
       
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
