using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletControler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dan; 
    public GameObject ViTriDan;
    Rigidbody2D rg;
    string name = "dan 3";
    public Button Pow;
    void Start()
    {
        //StartCoroutine(Dan());
        //Pow.onClick.AddListener(delegate
        //{
        //    GameObject Newrg = PoolManagerTank.Instance.SpawmPool(name, ViTriDan.transform.position, Dan.transform.rotation);
        //    rg = Newrg.GetComponent<Rigidbody2D>();
        //    rg.AddForce(ViTriDan.transform.up * 1000);
        //    //Dan1(Newrg);
        //    Debug.Log(name);
        //});
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            name = "dan 1";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            name = "dan 2";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            name = "dan 3";
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject Newrg = PoolManagerTank.Instance.SpawmPool(name, ViTriDan.transform.position, Dan.transform.rotation);
            //rg = Newrg.GetComponent<Rigidbody2D>();
            //rg.AddForce(ViTriDan.transform.up * 1000);
            ////Dan1(Newrg);
            //Debug.Log(name);
            Pow1();
        }
    }
    public void Pow1()
    {
        GameObject Newrg = PoolManagerTank.Instance.SpawmPool(name, ViTriDan.transform.position, Dan.transform.rotation);
        rg = Newrg.GetComponent<Rigidbody2D>();
        rg.AddForce(ViTriDan.transform.up * 1000);
        //Dan1(Newrg);
        Debug.Log(name);
        
    }
    
}
