using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class pauseUI : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> BtnTransform;
    private void OnEnable()
    {
        gameObject.transform.DOLocalMoveX(0, 0.4f).SetEase(Ease.OutBack).SetUpdate(true); ;
        StartCoroutine(IE_display());
      
    }
    IEnumerator IE_display()
    {
        //pau_menu_UI.transform.DOLocalMoveX(0,1).SetEase(Ease.OutElastic);
        yield return new WaitForSecondsRealtime(0.3f);
        for (int i = 0; i < BtnTransform.Count; i++)
        {
            BtnTransform[i].transform.DOScale(1, 1f).SetEase(Ease.OutElastic).SetUpdate(true);

            yield return new WaitForSecondsRealtime(0.1f);


        }

    }
    private void OnDisable()
    {
        gameObject.transform.DOLocalMoveX(820, 0).SetUpdate(true); ;
        for (int i = 0; i < BtnTransform.Count; i++)
        {
            BtnTransform[i].transform.DOScale(0, 0f).SetUpdate(true); ;
           



        }
    }
}
