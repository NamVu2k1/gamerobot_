using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallbot : MonoBehaviour
{
    // Start is called before the first frame update
    public static wallbot Instance;
    float time;
    float time_off;
    float timeLivedWallbot;
    private void Awake()
    {
        timeLivedWallbot = 5.5f + DataPlayer.GetlevelWallbot() * 0.3f;
    }
    void Start()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        
        time = Time.timeSinceLevelLoad;
        time_off = time + timeLivedWallbot;

        
        
    }
  
    // Update is called once per frame
    private void Update()
    {
        if(Time.timeSinceLevelLoad > time_off)
        {
            gameObject.SetActive(false);
        }
    }
    public void timeUpdate()
    {

        time_off = Time.timeSinceLevelLoad + timeLivedWallbot;
    }


}
