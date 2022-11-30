using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updatewallbot : MonoBehaviour
{
    // Start is called before the first frame update
    public Button update_btn;
    public Text cost_txt;
    public Text levelItem_txt;
    int cost;
    int levelitem;
    void Start()
    {
        levelitem = DataPlayer.GetlevelWallbot();
        UpdateviewLevelItem();
        update_btn.onClick.AddListener(Updatelevel);
    }

    // Update is called once per frame
   void Updatelevel()
    {
        if(levelitem < 10)
        {
            if (cost <= DataPlayer.GetCoin())
            {
                soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.buy);
                DataPlayer.SetCoin(-cost);
                DataPlayer.SetLevelWallbot();
                levelitem = DataPlayer.GetlevelWallbot();
                UpdateviewLevelItem();
            }
        }
       
    }
    void UpdateviewLevelItem()
    {
        if (levelitem >= 10)
        {
            levelItem_txt.text = "lv max";
            cost_txt.text = "...";
        }
        else
        {
            cost = DataPlayer.GetlevelWallbot() * 200 + 500;
            levelItem_txt.text = "lv " + DataPlayer.GetlevelWallbot();
            cost_txt.text = cost.ToString();
        }
        
    }
}
