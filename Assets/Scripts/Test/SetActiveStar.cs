using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetActiveStar : MonoBehaviour
{
    // Start is called before the first frame update
    int HP;
    public static int sodan = 0;
    public float timeDestroy;
    [SerializeField]
    TextMesh HP_box;
    private void Start()
    {
        HP = 100;
        HP_box.text = HP.ToString();
    }
    private void OnEnable()
    {
        HP = 100;
        updateText();
        // GetComponent<Rigidbody2D>().WakeUp();
        Invoke(nameof(HideBullet), timeDestroy);

    }
    private void HideBullet()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        // GetComponent<Rigidbody2D>().Sleep();
        CancelInvoke();
    }
    // Start is called before the first frame update
    private void OnParticleCollision(GameObject other)
    {

        gameObject.GetComponent<Animator>().Play("hitdame_1");
        HP -= 1;
        updateText();
        if(HP == 0)
        {
            gameObject.SetActive(false);
        }
    }
    void updateText()
    {
        HP_box.text = HP.ToString();
    }
}
