using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class eventMedal : MonoBehaviour
{
    // Start is called before the first frame update
    Slider slider;
    public Text amountGoldMedal_txt;
    public Button treasureChest;
    int amountGoldMedal;
    public GameObject costevent;
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        amountGoldMedal = DataPlayer.GeteventMedalGold();
        UpdateviewSlider();
        treasureChest.onClick.AddListener(OntreasureChest);

    }
    void OntreasureChest()
    {
        if(amountGoldMedal >= 5)
        {
            soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.treasurechest);
            DataPlayer.SeteventMedalGold(-5);
            amountGoldMedal = DataPlayer.GeteventMedalGold();

            UpdateviewSlider();
            costevent.transform.localPosition = new Vector3(0, 33, 0);
            var costevent_ = Instantiate(costevent, treasureChest.transform);
            costevent_.SetActive(true);
            costevent_.transform.DOLocalMoveY(100, 1).OnComplete(() => Destroy(costevent_));
        }
    }   
    void UpdateviewSlider()
    {
        slider.value = amountGoldMedal;
        amountGoldMedal_txt.text = amountGoldMedal + "/5";
    }
}
