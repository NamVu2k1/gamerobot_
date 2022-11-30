using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeValue : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider SliderChangeVolume;
    void Start()
    {
        SliderChangeVolume.value = AudioListener.volume;
        SliderChangeVolume.onValueChanged.AddListener( val=>sound.Instance.ChangeMasterVolume(val));
    }

   
}
