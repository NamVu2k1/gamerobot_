using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class sinhnv : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button[] mapsBtn;
    public List<RectTransform> maps;
    public List<RectTransform> save_rect;
    void Start()
    {
        List<RectTransform> save_rect = maps;
        for(int i=0; i< mapsBtn.Length;i++)
        {
            mapsBtn[i].onClick.AddListener(() =>
            {
                loadlevel(i+1);

            });
        }
        
      
        
    }
    private void OnEnable()
    {
      
        StartCoroutine(IE_display());
     
       
    }
   
    private void Reset()
    {
        
    }


    // Update is called once per frame
    void loadlevel(int lv)
    {
        SceneManager.LoadScene("Scenes/MenuGame Galaxy/environment");
        SceneManager.LoadScene($"Scenes/MenuGame Galaxy/map{lv}",LoadSceneMode.Additive);
    }
    IEnumerator IE_display()
    {
        
        yield return new WaitForSeconds(0.6f);
        
        for (int i = 0; i < maps.Count; i++)
        {
            maps[i].DOLocalMoveX(0, 0.6f).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(0.1f);
           
        }
        
    }
}
