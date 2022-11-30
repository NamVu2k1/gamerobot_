using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UI_toolbar : MonoBehaviour
{
    // Start is called before the first frame update
    public List< RectTransform> botBtn;
    void Start()
    {
       
        StartCoroutine(IE_display());
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    IEnumerator IE_display()
    {
        yield return new WaitForSeconds(0.4f);
        for(int i = 0; i < botBtn.Count;i++)
        {
            botBtn[i].DOLocalMoveY(0, 0.6f).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(0.1f);
        }
     
    }

}
