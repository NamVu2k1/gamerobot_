using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wallbotitem : MonoBehaviour
{
    public GameObject wallbot_obj;
    // Start is called before the first frame update
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            soundtriggeritem.Instance.OnPlaySound(SoundTypeItem.item);
            gameObject.SetActive(false);
            bulletparticle.Instance.wallbot_on();
        }
        if (collision.CompareTag("Death"))
        {
            gameObject.SetActive(false);
        }
    }

}
