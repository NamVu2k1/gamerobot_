using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textlevelplaying : MonoBehaviour
{
    // Start is called before the first frame update
    private Text leveltxt;
    void Start()
    {
        int level = DataPlayer.GetLevelPlaying();
        leveltxt = gameObject.GetComponent<Text>();
        leveltxt.text = "lv " + level ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
