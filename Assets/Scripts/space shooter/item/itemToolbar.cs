using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemToolbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Button add3_btn, x3_btn, wallBot_btn, RedPong_btn,Gun_btn;
    public Text add3_txt, x3_txt, wallBot_txt, RedPong_txt,Gun_txt;
    int[] limitItem = new int[] {4,4,4,4,4 };

    void Start()
    {
        UpdateviewAdd3();
        UpdateviewX3();
        UpdateviewWallBot();
        UpdateviewRedPong();
        UpdateviewGun();
        x3_btn.onClick.AddListener(Onx3);
        add3_btn.onClick.AddListener(Onadd3);
        wallBot_btn.onClick.AddListener(OnWallBot);
        RedPong_btn.onClick.AddListener(OnRedPong);
        Gun_btn.onClick.AddListener(OnGun);
    }
    
    // Update is called once per frame
    void Onadd3()
    {
        if (DataPlayer.GetItem(0) > 0 && limitItem[0]> 0)
        {
            DataPlayer.SetItem(0, -1);
            UpdateviewAdd3();
            bulletparticle.Instance.Triggeradd3();
            limitItem[0] -= 1;
        }
    }
    void Onx3()
    {
        if (DataPlayer.GetItem(1) > 0 && limitItem[1] > 0)
        {
            DataPlayer.SetItem(1, -1);
            UpdateviewX3();
            bulletparticle.Instance.Triggerx3();
            limitItem[1] -= 1;
        }
    }
    void OnWallBot()
    {
        if (DataPlayer.GetItem(2) > 0 && limitItem[2] > 0)
        {
            DataPlayer.SetItem(2, -1);
            UpdateviewWallBot();
            bulletparticle.Instance.wallbot_on();
            limitItem[2] -= 1;
        }
    }
    void OnRedPong()
    {
        if (DataPlayer.GetItem(3) > 0 && limitItem[3] > 0)
        {
            DataPlayer.SetItem(3, -1);
            UpdateviewRedPong();
            bulletparticle2.Instance.TriggerRedPong();
            limitItem[3] -= 1;
        }
    }
    void OnGun()
    {
        if(DataPlayer.GetItem(4) > 0 && limitItem[4] > 0)
        {
            DataPlayer.SetItem(4, -1);
            UpdateviewGun();
            bulletparticle3.Instance.TriggerGun();
            limitItem[4] -= 1;
        }
      
    }
    // text
    void UpdateviewAdd3()
    {
        add3_txt.text = "x" + DataPlayer.GetItem(0).ToString();
    }
    void UpdateviewX3()
    {
        x3_txt.text = "x" + DataPlayer.GetItem(1).ToString();
    }
    void UpdateviewWallBot()
    {
        wallBot_txt.text = "x" + DataPlayer.GetItem(2).ToString();
    }
    void UpdateviewRedPong()
    {
        RedPong_txt.text = "x" + DataPlayer.GetItem(3).ToString();
    }
    void UpdateviewGun()
    {
        Gun_txt.text = "x" + DataPlayer.GetItem(4).ToString();
    }
}
