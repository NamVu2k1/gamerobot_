using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartCs : MonoBehaviour
{
    // Start is called before the first frame update
    public float fade = 0;
    private static StartCs _instance;
    public static StartCs Instance => _instance;
    public Button StartBtn;
    public Material Dissolve;

    [Range(0, 0.5f)]
    public float SpeedShader;
    void Start()
    {
        _instance = this;
        StartBtn.onClick.AddListener(OnPlay);
    }
    void OnPlay()
    {
        fade = 0;
        Dissolve.SetFloat("_Fade", fade);
    }
    // Update is called once per frame
    void Update()
    {
       
        if(fade <=1)
        {
             fade += Time.deltaTime * SpeedShader;
             
        }
    }
}
