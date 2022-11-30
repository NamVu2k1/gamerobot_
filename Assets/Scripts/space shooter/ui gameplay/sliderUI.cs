using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sliderUI : MonoBehaviour
{
    // Start is called before the first frame update
    public static sliderUI Instance;

    bool OnSlider =false;
    Slider slider;
    void Start()
    {
        Instance = this;
        slider = gameObject.GetComponent<Slider>();
    }
    public void realtime()
    {
        OnSlider = true;
    }
    // Update is called once per frame
    void Update()
    {
   
        if (OnSlider == true)
        {
            slider.value -= Time.deltaTime;
        }
      
    }
    public float GetSliderValue()
    {

        return slider.value;
    }
}
