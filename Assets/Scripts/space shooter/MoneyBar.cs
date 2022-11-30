    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Text coinText;
    private void Start()
    {
        UpdateView();
    }
    public void UpdateView()
    {
        coinText.text = DataPlayer.GetCoin().ToString();
      
    }
    private void OnEnable()
    {
        DataPlayer.AddListener(UpdateView);
    }
    private void OnDisable()
    {
        DataPlayer.RemoveListener(UpdateView);

    }
}
