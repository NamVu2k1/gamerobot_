using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button UiHomeBtn, UiSettingBtn, UiShopBtn;
    public GameObject uiHome,uiSetting ,uiShop;
    public float timdDelay;
    
    private void Start()
    {
        uiHome.transform.DOLocalMoveY(5, timdDelay).SetEase(Ease.OutBack);
       
    }
   
    public void upShop()
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        uiShop.SetActive(true);
     
        uiShop.transform.DOLocalMoveX(0, timdDelay).SetEase(Ease.OutBack);
        uiHome.transform.DOLocalMoveX(1015f, timdDelay).SetEase(Ease.OutBack);
        uiSetting.transform.DOLocalMoveX(2030, timdDelay).SetEase(Ease.OutBack);

        Invoke("setactivhome", timdDelay);
        Invoke("setactivsetting", timdDelay);
    }
    public void upHome()
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        uiHome.SetActive(true);
        uiShop.transform.DOLocalMoveX(-1015f, timdDelay).SetEase(Ease.OutBack);
        uiHome.transform.DOLocalMoveX(0, timdDelay).SetEase(Ease.OutBack);
        uiSetting.transform.DOLocalMoveX(1015f, timdDelay).SetEase(Ease.OutBack);
        Invoke("setactivshop", timdDelay);
        Invoke("setactivsetting", timdDelay);
    }
    public void upSetting()
    {
        soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.button);
        uiSetting.SetActive(true);
        uiShop.transform.DOLocalMoveX(-2030, timdDelay).SetEase(Ease.OutBack);
        uiHome.transform.DOLocalMoveX(-1015, timdDelay).SetEase(Ease.OutBack);
        uiSetting.transform.DOLocalMoveX(0, timdDelay).SetEase(Ease.OutBack);
        Invoke("setactivshop", timdDelay);
        Invoke("setactivhome", timdDelay);
    }
    IEnumerator IE_Display(float delayStart)
    {
        
       
      
        Debug.Log(1);
        yield return new WaitForSeconds(delayStart);
 
    }

    void setactivshop()
    {
        uiShop.SetActive(false);
    }
    void setactivhome()
    {
        uiHome.SetActive(false);
    }
    void setactivsetting()
    {
        uiSetting.SetActive(false);
    }
}
