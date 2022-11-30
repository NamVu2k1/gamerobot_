using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dissolve : MonoBehaviour
{
    // Start is called before the first frame update

    public bool _onMouse= false;
    
    public Material _dissolve;
    private void Awake()
    {
      
    }
   
    // Update is called once per frame
    void Update()
    {
        if(StartCs.Instance.fade <=1)
        {
         
            _dissolve.SetFloat("_Fade", StartCs.Instance.fade);
           
        }
    }
    private void OnMouseUp()
    {
        Debug.Log("Up");
    }
    private void OnMouseEnter()
    {
        _onMouse = true;
        Debug.Log("1");
    }
        

}
