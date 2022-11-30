using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class arr : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
        int[] a = new int[3];
        a[0] = 1;
        a[1] = 2;
        a[2] = 3;
        List<int> lsta = new List<int>();
        lsta.Add(1);
        lsta.Add(2);
        lsta.Add(3);
        lsta.Add(4);
        lsta.Remove(2);
        
        Debug.Log(lsta.IndexOf(1));
        Debug.Log(lsta.IndexOf(3));
        Stack mystack = new Stack();
    }
}
