using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletPool : MonoBehaviour
{
    public static int sodan = 0;
    public float timeDestroy;
    private void OnEnable()
    {
       // GetComponent<Rigidbody2D>().WakeUp();
        Invoke(nameof(HideBullet),timeDestroy);

    }
    private void HideBullet()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
       // GetComponent<Rigidbody2D>().Sleep();
        CancelInvoke();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
