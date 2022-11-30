using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testWaitForSeconds : MonoBehaviour
{
    // Start is called before the first frame update
    Coroutine lastRoutine = null;
    void Start()
    {
        lastRoutine = StartCoroutine(Xoayban()); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(lastRoutine);
        }
    }
    private IEnumerator Xoayban()
    {
        while(true)
        {
            Debug.Log("dung 5 s");
            yield return new WaitForSeconds(5);
            Debug.Log("dung 10 s");
            yield return new WaitForSeconds(10);
        }
    }
}
