using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generictest<G> : MonoBehaviour where G:Generictest<G>
{
    // Start is called before the first frame update
    private G[] item;
    public G[] Item
    {
        get { return item; }
    }


    public void Swap<T>(ref T a,ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }
    void Start()
    {
        string str1 = "nam", str2 = "vu";
        Swap<string>(ref str1, ref str2);

        int in1 = 1, in2 = 2;
        Swap<int>(ref in1, ref in2);
        Debug.Log(str1 + " " + str2 + " ");
        Debug.Log(in1 + " " + in2 + " ");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
