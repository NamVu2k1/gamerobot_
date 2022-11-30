using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    // Start is called before the first frame update
    private static singleton instance ;
    private singleton()
    {

    }
    public void swap()
    {

    }
    public static singleton Instance()
    {
        if(instance = null)
        {
            instance = new singleton();
        }
        return instance;
    }
  
    
    private void Start()
    {
       
    }
}
