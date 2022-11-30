using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieuKhienSungCach2 : MonoBehaviour
{
    
    Coroutine lastRouTine = null;
    public Coroutine BanDan = null;
    public GameObject Dan;
    public GameObject ViTriDan;
    bool StatusQuay;
   
    Rigidbody2D rg;
    
    // Start is called before the first frame update
    void Start()
    {
        lastRouTine = StartCoroutine(Xoayban());  
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(lastRouTine);
        }
        if(StatusQuay == true)
        {
            transform.Rotate(new Vector3(0, 0, 1), 30 * Time.deltaTime);
        }     
    }
    private IEnumerator Xoayban()
    {
        while(true)
        {
           
            StatusQuay = false;
            BanDan = StartCoroutine(Ban());
            yield return new WaitForSeconds(1);
            StopCoroutine(BanDan);
            StatusQuay = true;
            yield return new WaitForSeconds(1);
        }
    }
    private IEnumerator Ban()
    {
        int Dem = 0;
        while (Dem < 3)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject Newrg = PoolManager.Instance.SpawmPool("dan 1",ViTriDan.transform.position, Dan.transform.rotation);
           // GameObject Newrg = GetComponent<PoolManager>().SpawmPool("dan 1", ViTriDan.transform.position, Dan.transform.rotation);     
            rg = Newrg.GetComponent<Rigidbody2D>();
            rg.AddForce(-ViTriDan.transform.up * 500);
            Dem++;
        }
    }   
}
