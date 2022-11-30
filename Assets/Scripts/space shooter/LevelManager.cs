using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List< Sprite> sprite_;
    public Button Next, Prev;
    public GameObject lvPassBtn, LvUnpassBtn, LvNowBtn;
    public Transform Content;
    public Text cPage;
    int pageCurrent = 0;
    int pageLimit = 15;
    public int AllLevel = 100;
    class item
    {
        public GameObject ObjLevel;
    }
    List<item> items = new List<item>();

    public void resetLock()
    {
        item newItem;
        int _lock = DataPlayer.GetLevelNow();
        
        for (int i = 1; i <= AllLevel; i++)
        {
            newItem = new item();
            if (i == _lock)
            {
                GameObject newbt = Instantiate(LvNowBtn, Content);
                newbt.SetActive(false);
                int level = i;
                newbt.transform.GetChild(0).GetComponent<Text>().text = level.ToString(); 
                newbt.name = "level_" + level + " lv now";
                newbt.GetComponent<Button>().onClick.AddListener(() => loadlevel(level));
                newItem.ObjLevel = newbt;

            }
            if (i < _lock)
            {
                GameObject newbt = Instantiate(lvPassBtn, Content);
                newbt.SetActive(false);                
                int level = i;
                newbt.transform.GetChild(0).GetComponent<Text>().text = level.ToString() ;
                newbt.transform.GetChild(1).GetComponent<Image>().sprite = sprite_[DataPlayer.GetMedal(level)];
                newbt.name = "level_" + level;
                newbt.GetComponent<Button>().onClick.AddListener(() => loadlevel(level));
                newItem.ObjLevel = newbt;
            }
            if (i > _lock)
            {
                GameObject newbt = Instantiate(LvUnpassBtn, Content);
                newbt.SetActive(false);
                int level = i;
                newbt.transform.GetChild(0).GetComponent<Text>().text = level.ToString();                
                newbt.name = "level_" + level;
                //newbt.GetComponent<Button>().onClick.AddListener(() => loadlevel(int.Parse(x)));
                newItem.ObjLevel = newbt;
            }
            items.Add(newItem);
        }
    }
    void Btn_Next_Prev(int k)
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        pageCurrent += k;
        if ((pageCurrent > (AllLevel / pageLimit) + 1 || (pageCurrent < 1)))
        {
            pageCurrent = 1;
        }
        cPage.text = pageCurrent.ToString();
        var lstItem = GetPageitems(pageCurrent);
        for (int i =0 ; i < AllLevel; i++)
        {
            items[i].ObjLevel.SetActive(false);
        }
        foreach (var p in lstItem)
        {
            p.ObjLevel.SetActive(true);
        }
    }
    IEnumerable<item> GetPageitems(int pagenum)
    {
        return items.Skip((pagenum - 1) * pageLimit).Take(pageLimit);
    }

    void Start()
    {
        
        Next.onClick.AddListener(() => Btn_Next_Prev(1));
        Prev.onClick.AddListener(()=> Btn_Next_Prev(-1));
        int pageOfLevelNow = (DataPlayer.GetLevelNow() -1 )/ 15 + 1;
        resetLock();
        Btn_Next_Prev(pageOfLevelNow);
    }

    void loadlevel(int lv)
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        DataPlayer.SetLevelPlaying(lv);
        SceneManager.LoadScene("Scenes/maps/main");
        SceneManager.LoadScene($"Scenes/maps/map{lv}", LoadSceneMode.Additive);
    }

}
