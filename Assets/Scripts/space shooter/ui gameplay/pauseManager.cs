using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class pauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pau_menu_UI;
  
    public Button homeBtn, continueBtn, reload,pauseBtn;
    void Start()
    {
        pau_menu_UI.SetActive(false);
        pauseBtn.onClick.AddListener(onPauseBtn);
        continueBtn.onClick.AddListener(onContinueBtn);
        homeBtn.onClick.AddListener(onHomeBtn);
        reload.onClick.AddListener(onReload);
    }


    // Update is called once per frame
    void onPauseBtn()
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        pau_menu_UI.SetActive(true);
        
      
        Time.timeScale = 0;
    }
    void onContinueBtn()
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        pau_menu_UI.SetActive(false);
        Time.timeScale = 1;
    }
    void onHomeBtn()
    {
       // soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        SceneManager.LoadScene("Scenes/MenuGame");
        Time.timeScale = 1;
    }
    void onReload()
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        Time.timeScale = 1;
        int inLevel = DataPlayer.GetLevelPlaying();
        SceneManager.LoadScene("Scenes/maps/main");
        SceneManager.LoadScene($"Scenes/maps/map{inLevel}", LoadSceneMode.Additive);
    }

}
