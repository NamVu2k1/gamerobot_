using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Shoptest : MonoBehaviour
{
    // Start is called before the first frame update
    public ScrollRect ScrollMap;
    //
    public Button BackBtn;
    public Button NextBtn;
    public GameObject ItemBtn;
    public Transform Content;
    public Text cPage;
    int pageCurrent = 1;
    int pageLimtit = 18;
    int AllItem = 60;
    public class item
    {
        public GameObject objItem;
    }
    public List<item> Items = new List<item>();

    public void MenuShop()
    {
        item NewItem;
        for(int i = 1; i <= AllItem; i++)
        {
            NewItem = new item();
            GameObject newbt = Instantiate(ItemBtn, Content);
            newbt.SetActive(true);
            NewItem.objItem = newbt;
            Items.Add(NewItem);
        }
    }

    void btnNext(int k)
    {
        pageCurrent += k;
        if((pageCurrent > ((AllItem/pageLimtit) + 1))|| (pageCurrent <1))
        {
            pageCurrent = 1;
        }
        cPage.text = pageCurrent.ToString();
        var lstItems = GetPageItems(pageCurrent);
        for(int i = 0; i < AllItem; i++)
        {
            Items[i].objItem.SetActive(false);
        }
        for(int i= 0; i < AllItem; i++)
        {
            foreach(var pt in GetPageItems(pageCurrent))
            {
                pt.objItem.SetActive(true);
            }
        }
    }
    IEnumerable <item> GetPageItems(int pagenum)
    {
        return Items.Skip((pagenum - 1) * pageLimtit).Take(pageLimtit);
    }
    void Start()
    {
        BackBtn.onClick.AddListener(() => btnNext(-1));
        NextBtn.onClick.AddListener(() => btnNext(1));
        MenuShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
