using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateGunbullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Button update_btn;
    public Text cost_txt;
    public Text levelItem_txt;
    int levelitem;
    int cost;
    void Start()
    {
        levelitem = DataPlayer.GetlevelGunbullet();
        UpdateviewLevelItem();
        update_btn.onClick.AddListener(Updatelevel);
    }

    // Update is called once per frame
    void Updatelevel()
    {
        if(levelitem < 5)
        {
            if (cost <= DataPlayer.GetCoin())
            {

                soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.buy);
                DataPlayer.SetCoin(-cost);
                DataPlayer.SetlevelGunbullet();
                levelitem = DataPlayer.GetlevelGunbullet();
                UpdateviewLevelItem();
            }
        }
       
    }
    void UpdateviewLevelItem()
    {
        if (levelitem == 5)
        {
            levelItem_txt.text = "lv max";
            cost_txt.text = "...";
        }
        else
        {
            cost = DataPlayer.GetlevelGunbullet() * 500 + 500;
            levelItem_txt.text = "lv " + DataPlayer.GetlevelGunbullet();
            cost_txt.text = cost.ToString();
        }

    }
}
