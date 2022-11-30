using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class LevelGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Button BackBtn;
    public Button NextBtn;
    public ScrollRect ScrollMap;
    public GameObject LvPassBtn;
    public GameObject LvUnPassBtn;
    public GameObject LvNowBtn;
    public Transform Content;
    public Text cPage;
    int pageCurrent = 0;
    int pageLimit = 12;
    int AllLevel = 100;
    class item
    {
        public GameObject ObjLevel;
    }
    List<item> items = new List<item>();
    public void resetLock()
    {
        item newItem;
        int nunUnlock = 5;
        for(int  i = 1; i <= AllLevel; i++)
        {
            newItem = new item();
            if(i == nunUnlock)
            {
                GameObject newbt = Instantiate(LvNowBtn, Content);
                newbt.SetActive(false);
                newbt.transform.GetChild(0).GetComponent<Text>().text = i.ToString() + "lv now";
                newbt.transform.name = "level_" + i +" lv now";
                newbt.GetComponent<Button>().onClick.AddListener(delegate
                {

                });
                newItem.ObjLevel = newbt;
            }
            else if( i < nunUnlock)
            {
                GameObject newbt = Instantiate(LvPassBtn, Content);
                newbt.SetActive(false);
                newbt.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
                newbt.transform.name = "level_" + i;
                newbt.GetComponent<Button>().onClick.AddListener(delegate
                {

                });
                newItem.ObjLevel = newbt;
            }
            else if( i > nunUnlock)
            {
                GameObject newbt = Instantiate(LvUnPassBtn, Content);
                newbt.SetActive(false);
                newbt.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
                newbt.transform.name = "level_" + i + "";
                newbt.GetComponent<Button>().onClick.AddListener(delegate
                {

                });
                newItem.ObjLevel = newbt;
            }
            items.Add(newItem);
        }
    }
    void btnNext(int k)
    {
        pageCurrent += k;
        if ((pageCurrent > (AllLevel / pageLimit) + 1) || (pageCurrent < 1))
            pageCurrent = 1;
        cPage.text = "page" + pageCurrent;

        var lstItems = GetPageItems(pageCurrent);
      
        for (int i = 0; i < AllLevel; i++)
        {
            items[i].ObjLevel.SetActive(false);
        }
      
       
        foreach(var pt in lstItems)
        {
            pt.ObjLevel.SetActive(true);
 
        }
        
    } 
    IEnumerable <item> GetPageItems(int pagenum)
    {
        //1 2 3 4 5 6
        //page=1, 2 pt
        //kip 0 take 2
        //kip 2 take 2
        return items.Skip((pagenum - 1) * pageLimit).Take(pageLimit);
    }
    void Start()
    {
        
        BackBtn.onClick.AddListener(() => btnNext(-1));
        NextBtn.onClick.AddListener(() => btnNext(1));
        resetLock();
        btnNext(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
