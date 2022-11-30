using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class panelDangKy : MonoBehaviour
{
    // Start is called before the first frame update

    public InputField txtDangNhap;
    public Button btnDangNhap;
    void Start()
    {
        btnDangNhap.GetComponent<Button>().onClick.AddListener(delegate {
            string value = txtDangNhap.text;
            Debug.Log("ten dang nhap cua ban la:" + value);
        
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
