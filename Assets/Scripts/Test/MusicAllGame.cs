using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAllGame : MonoBehaviour
{
    public static MusicAllGame Instance;  
    public static bool isMusic = true;
    public AudioSource aS;
    public AudioClip[] aClip;
    private void Awake()
    {
        if (Instance == null)
        {

            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
           Destroy(gameObject);
            
        }
       
    }
    public void PlayMusicGame(int music)
    {
        if(isMusic)
        {
            //aS.Stop();
            aS.PlayOneShot(aClip[music]);
        }
    }
    // Update is called once per frame
    private void Start()
    {
      
    }
    void Update()
    {
        Debug.Log(aS.name);
    }
}
