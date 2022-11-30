using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class costevent : MonoBehaviour
{
    // Start is called before the first frame update
    Text cost_txt;
    int cost;
    void Start()
    {
        cost = Random.Range(300, 600);
        cost_txt = gameObject.transform.GetChild(0).GetComponent<Text>();
        cost_txt.text = cost.ToString();
        DataPlayer.SetCoin(cost);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
