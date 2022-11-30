using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveText : MonoBehaviour
{
    // Start is called before the first frame update
    bool StatusCoin = false;
    public int Coins;
    void Start()
    {
        StartCoroutine(ShowPoints(Coins));    }
    public IEnumerator ShowPoints(int coins)
    {
        StatusCoin = true;
        yield return new WaitForSeconds(2f);
        StatusCoin = false;
        Destroy(gameObject);
        gameObject.SendMessage("AddCoin", coins);
        Debug.Log(PlayerPrefs.GetInt("Score", 0));
        yield return new WaitForSeconds(2f);    
            
    }

    // Update is called once per frame
    void Update()
    {
        if(StatusCoin)
        {
            gameObject.transform.position += Vector3.up * Time.deltaTime;
            transform.Rotate(new Vector3(0, 1, 0), 90 * Time.deltaTime);
            GetComponent<TextMesh>().text ="+" + Coins.ToString();
           // MusicAllGame.Instance.PlayMusicGame(0);
        }
    }
     public void AddCoin(int Coins)
    {
        int coins = PlayerPrefs.GetInt("Score", 0);
        coins += Coins;
        PlayerPrefs.SetInt("Score", coins);
        
    }
}
