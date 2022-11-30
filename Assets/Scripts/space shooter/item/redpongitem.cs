using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redpongitem : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.item);
            bulletparticle2.Instance.TriggerRedPong();
            gameObject.SetActive(false);
        }
         if (col.CompareTag("Death"))
        {
            gameObject.SetActive(false);
        }
    }
}
