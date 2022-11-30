using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieuKhienSung : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dan;
    public GameObject ViTriDan;
    bool blDan;
    bool StatusQuay;
    float StartTime;
    float StartGun;
    bool statusBan;
    float midTime;
    float midGunTime;
    float getTime;
    Rigidbody2D rg;
    int dem;

    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        midTime = Time.time - StartTime;
        if (midTime <1f)
        {
            StatusQuay = false;
            getTime = Time.time;     
        }
        else
        {

            if(Time.time - getTime < 1)
            {
                StatusQuay = true;
            }
            else
            {
                StartTime = Time.time;
            }
        }
        if(StatusQuay == true)
        {
            dem = 0;
            transform.Rotate(new Vector3(0, 0, 1), 30 * Time.deltaTime);
            StartGun = Time.time;
        }
        else
        {
            midGunTime = Time.time - StartGun;
            if(dem < 3)
            {
                if(midGunTime > 0.3f)
                {
                    GameObject NewRg;
                    NewRg = Instantiate(Dan, ViTriDan.transform.position, Dan.transform.rotation) as GameObject;
                    NewRg.SetActive(true);
                    rg = NewRg.GetComponent<Rigidbody2D>();
                    rg.AddForce(-ViTriDan.transform.up * 200);
                    StartGun += 0.3f;
                    dem++;

                }
            }
           
        }
        Debug.Log("MidGuntime:" + midGunTime);
        Debug.Log("dem:" + dem);
        Debug.Log("Midtime:" + midTime);
        Debug.Log("StatusQuay:" + StatusQuay);
    }
   
}
