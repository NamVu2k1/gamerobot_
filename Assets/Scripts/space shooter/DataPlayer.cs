using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class DataPlayer
{
    private const string ALL_DATA = "all_data";
    private static AllData allData;
    private static UnityEvent updateCoinEvent = new UnityEvent();
    static DataPlayer()
    {
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(ALL_DATA));
        if(allData == null)
        {
            allData = new AllData
            {
                coin = 300000,
                levelNow = 90,
                levelWallbot = 1,
                levelRedpong = 1,
                levelScalePlayer = 1,
                levelGunbullet = 1,
                medals = new int[100],
                items = new int[10],
                eventMedalGold = 0,
            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    public static void SetItem(int id, int amount)
    {
        allData.SetItem(id, amount);
        SaveData();
    }
    public static int GetItem(int id)
    {
        return allData.GetItem(id);
    }

    public static int GetCoin()
    {
        return allData.GetCoin();
    }
    public static void SetCoin(int value)
    {
        allData.SetCoin(value);
        updateCoinEvent?.Invoke();
        SaveData();
    }

    public static void AddListener(UnityAction updatecoin)
    {
        updateCoinEvent.AddListener(updatecoin);
    }
    public static void RemoveListener(UnityAction updatecoin)
    {
        updateCoinEvent.RemoveListener(updatecoin);
    }
    public static void SetLevelPlaying(int value)
    {
        allData.SetLevelPlaying(value);
        SaveData();
    }
    public static int GetLevelPlaying()
    {
        return allData.GetLevelPlaying();
    }
    public static void SetLevelNow()
    {
        allData.SetLevelNow();
        SaveData();
    }
    public static int GetLevelNow()
    {
        return allData.GetLevelNow();
    }

    public static void SetMedal(int level, int thisMedal)
    {
        allData.SetMedal(level, thisMedal);
        SaveData();
    }
    public static int GetMedal(int level)
    {
        return allData.GetMedal(level);
    }

    public static int GetlevelWallbot()
    {
        return allData.levelWallbot;
    }
    public static void SetLevelWallbot()
    {
        allData.SetLevelWallbot();
        SaveData();
    }
    public static int GetlevelRedpong()
    {
        return allData.GetlevelRedpong();
    }
    public static void SetLevelRedpong()
    {
        allData.SetLevelRedpong();
        SaveData();
    }

    public static int GetlevelScalePlayer()
    {
        return allData.GetlevelScalePlayer();
        
    }
    public static void SetlevelScalePlayer()
    {
        allData.SetlevelScalePlayer();
        SaveData();
    }
    public static int GeteventMedalGold()
    {
        return allData.GeteventMedalGold() ;
    }
    public static void SeteventMedalGold(int value)
    {
        allData.SeteventMedalGold(value);
        SaveData();
    }
    public static int GetlevelGunbullet()
    {
        return allData.GetlevelGunbullet();
    }
    public static void SetlevelGunbullet()
    {
        allData.SetlevelGunbullet();
        SaveData();
    }

}




public class AllData
{
    //public int[] test;
    public int[] items;
    public int coin;

    
    public int[] medals;
    public int eventMedalGold;

    public int levelPlaying;
    public int levelNow;

    public int levelWallbot;
    public int levelRedpong;
    public int levelScalePlayer;
    public int levelGunbullet;

    public int GetlevelGunbullet()
    {
        return levelGunbullet;
    }
    public void SetlevelGunbullet()
    {
        levelGunbullet += 1;
    }
    //
    public int GeteventMedalGold()
    {
        return eventMedalGold;
    }
    public void SeteventMedalGold(int value)
    {
        eventMedalGold += value;
    }
    //
    public int GetlevelScalePlayer()
    {
        return levelScalePlayer;
    }
    public void SetlevelScalePlayer()
    {
        levelScalePlayer += 1;
    }

    //
    public int GetlevelRedpong()
    {
        return levelRedpong;
    }
    public void SetLevelRedpong()
    {
        levelRedpong += 1;
    }//
    public int GetlevelWallbot()
    {
        return levelWallbot;
    }
    public void SetLevelWallbot()
    {
        levelWallbot += 1;
    }//
    public void SetItem(int id,int amount)
    {
        items[id] += amount;
    }
    public int GetItem(int id)
    {
        return items[id];
    } //
    public int GetCoin()
    {
        return coin;
    }
    public  void SetCoin(int value)
    {
        coin += value;
    }//
   
    public void SetLevelPlaying(int value)
    {
        levelPlaying = value;
    }
    public int GetLevelPlaying()
    {
        return levelPlaying;
    }
    public void SetLevelNow()
    {
        levelNow += 1;
    }
    public int GetLevelNow()
    {
        return levelNow;
    }//
    public void SetMedal(int level,int thisMedal)
    {
        medals[level] = thisMedal;
    }
    public int GetMedal(int level)
    {
        return medals[level];
    }//
}
