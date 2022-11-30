using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundType
{
    lose = 1,
    pong = 2,
}
public class sound : MonoBehaviour
{
    // Start is called before the first frame update
    public static sound Instance;
    public AudioSource audiofx;
   
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);    
        }
        else
        {
            Destroy(gameObject);
        }
  
    }
    private void OnValidate()
    {
        if(audiofx == null)
        {
            audiofx = gameObject.AddComponent<AudioSource>();            
            audiofx.playOnAwake = false;
        }
    }
    public void OnPlaySound(SoundType soundType)
    {
        var audio = Resources.Load<AudioClip>($"sounds/{soundType.ToString()}");
      
        if (audiofx.isPlaying == false )
        {
            audiofx.PlayOneShot(audio);
        }
    }
    public void ChangeMasterVolume(float Value)
    {
        AudioListener.volume = Value;
    }
   
    //public void OnPlayButtonsound()
    //{
    //    if (audiofx.isPlaying == false)
    //    {
    //        audiofx.PlayOneShot(buttonclip);
    //    }

    //}
}
