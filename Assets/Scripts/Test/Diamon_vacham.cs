using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Diamon_vacham : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textCoins;
    public ParticleSystem ParticleCoins;
    [SerializeField]
    LayerMask Point;
    bool once = true;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "DoiTuong" && once)
        {
            once = false;
            MusicAllGame.Instance.PlayMusicGame(1);
            Debug.Log("va cham");
            GameObject textClone = Instantiate(textCoins, transform.position,transform.rotation);
            var em = ParticleCoins.emission;
            em.enabled = true;
            ParticleCoins.Play();
            Destroy(GetComponent<SpriteRenderer>());
            textClone.SetActive(true);
            Invoke(nameof(DestroyObj),ParticleCoins.duration);
        }
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }

}
