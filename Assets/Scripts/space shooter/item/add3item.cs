using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add3item : MonoBehaviour
{
    // Start is called before the first frame update
 
  
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.item);
            bulletparticle.Instance.Triggeradd3();
            gameObject.SetActive(false);
        }
         if(col.CompareTag("Death"))
        {
       
            gameObject.SetActive(false);
        }
    }
  
}
