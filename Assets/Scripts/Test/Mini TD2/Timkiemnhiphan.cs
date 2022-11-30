using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timkiemnhiphan : MonoBehaviour
{
    // Start is called before the first frame update
    static int BinarySearch(int[] arr,int l, int r, int x)
    {
        if(r > l)
        {
            int mid = l + (r - l) / 2;
            if(arr[mid] == x)
            {
                return mid;
            }
            if(arr[mid] > x)
            {
                return BinarySearch(arr, l, mid - 1, x);
            }
            return BinarySearch(arr, mid + 1, r, x);
        }
        return -1;
    }
    void Start()
    {
        int[] arr = { 3, 5, 7, 9, 10 };
        int x = 7;
        int index = BinarySearch(arr, 0, arr.Length - 1, x);
        Debug.Log(index);
    }

    // Update is called once per frame
    
}
