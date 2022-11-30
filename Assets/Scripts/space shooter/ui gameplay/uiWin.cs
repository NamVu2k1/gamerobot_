using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class uiWin : MonoBehaviour
{
    public Button reload, menu, next;
    public Image medal;
    public List<Sprite> lstMdedal;
    public List<GameObject> BtnTransform;
    public Text wintxt;   
    int thismedal;
 
    private void OnEnable()
    {
        thismedal = (int)(sliderUI.Instance.GetSliderValue()/60);
        int valueMedal = (thismedal + 1) * 25;
        int bonus = Random.Range(20, 60);
        CheckLevelNow(valueMedal, bonus);
        gameObject.transform.DOLocalMoveX(0, 0.4f).SetEase(Ease.OutBack);
        menu.onClick.AddListener(OnMenu);
        reload.onClick.AddListener(OnReload);
        next.onClick.AddListener(OnNext);
        Invoke(nameof(MedalOn), 0.4f);
        StartCoroutine(IE_display());
    }

    void Start()
    {
        

    }
    void MedalOn()
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.win);
        if(thismedal == 2)
        {
            DataPlayer.SeteventMedalGold(1);
            medal.sprite = lstMdedal[2];
        }
        else if(thismedal == 1)
        {
            medal.sprite = lstMdedal[1];
        }
        else
        {
            medal.sprite = lstMdedal[0];
        }
        
        medal.transform.DOScale(1, 1f).SetEase(Ease.OutElastic);
        
    }
    IEnumerator IE_display()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < BtnTransform.Count; i++)
        {
            BtnTransform[i].transform.DOScale(1, 1f).SetEase(Ease.OutElastic);
            yield return new WaitForSeconds(0.1f);
        }
    }
    void OnReload()
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        int inLevel = DataPlayer.GetLevelPlaying();
        SceneManager.LoadScene("Scenes/maps/main");
        SceneManager.LoadScene($"Scenes/maps/map{inLevel}", LoadSceneMode.Additive);
    }
    void OnMenu()
    {
        //soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        SceneManager.LoadScene("Scenes/MenuGame");
    }
    void OnNext()
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        int inLevel = DataPlayer.GetLevelPlaying();
        DataPlayer.SetLevelPlaying(inLevel + 1);
        
        SceneManager.LoadScene("Scenes/maps/main");
        SceneManager.LoadScene($"Scenes/maps/map{inLevel+1}", LoadSceneMode.Additive);
    }
    void CheckLevelNow(int valueMedal, int bonus)
    {
        int levelplaying = DataPlayer.GetLevelPlaying();
        DataPlayer.SetCoin(valueMedal + bonus);
        int levelNow = DataPlayer.GetLevelNow();
        if(thismedal > DataPlayer.GetMedal(levelplaying))
        {
            DataPlayer.SetMedal(levelplaying, thismedal);
        }
        
        if(levelplaying == levelNow)
        {
            DataPlayer.SetLevelNow();
        }
        wintxt.text = $"Medal      +{valueMedal}\nbonus      +{bonus}";
        wintxt.transform.DOMoveY(0, 1f).SetEase(Ease.OutBack);
        wintxt.DOColor(Color.white, 1f);
    }

}
