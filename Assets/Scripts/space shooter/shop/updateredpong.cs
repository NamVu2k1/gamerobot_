using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateredpong : MonoBehaviour
{
    // Start is called before the first frame update
    public Button update_btn;
    public Text cost_txt;
    public Text levelItem_txt;
    int levelitem;
    int cost;
    void Start()
    {
        levelitem = DataPlayer.GetlevelRedpong();
        UpdateviewLevelItem();
        update_btn.onClick.AddListener(Updatelevel);
    }

    // Update is called once per frame
    void Updatelevel()
    {
        if (levelitem < 5)
        {
            if (cost <= DataPlayer.GetCoin())
            {
                soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.buy);
                DataPlayer.SetCoin(-cost);
                DataPlayer.SetLevelRedpong();
                levelitem = DataPlayer.GetlevelRedpong();
                UpdateviewLevelItem();
            }
        }
           
    }
    void UpdateviewLevelItem()
    {
        if (levelitem >= 5)
        {
            levelItem_txt.text = "lv max";
            cost_txt.text = "...";
        }
        else
        {
            cost = DataPlayer.GetlevelRedpong() * 500 + 600;
            levelItem_txt.text = "lv " + DataPlayer.GetlevelRedpong();
            cost_txt.text = cost.ToString();
        }
       
    }
}
