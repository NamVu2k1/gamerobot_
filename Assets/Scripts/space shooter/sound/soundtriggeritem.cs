using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundTypeItem
{
 
    item = 0,
    lose = 1,
    win =2,
    button = 3,
    buy = 4,
    gun = 5,
    treasurechest = 6
}
public class soundtriggeritem : MonoBehaviour
{
    // Start is called before the first frame update
    public static soundtriggeritem Instance;
    public AudioSource audiofx;

    private void Awake()
    {
        if (Instance == null)
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
        if (audiofx == null)
        {
            audiofx = gameObject.AddComponent<AudioSource>();

            audiofx.playOnAwake = false;
        }
    }
    public void OnPlaySound(SoundTypeItem soundType)
    {
        var audio = Resources.Load<AudioClip>($"sounds/{soundType.ToString()}");

       
        
            audiofx.PlayOneShot(audio);
        
    }
    public void ChangeMasterVolume(float Value)
    {
        audiofx.volume = Value;
    }   

    //public void OnPlayButtonsound()
    //{
    //    if (audiofx.isPlaying == false)
    //    {
    //        audiofx.PlayOneShot(buttonclip);
    //    }

    //}
}

