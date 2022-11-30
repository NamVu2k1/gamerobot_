using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rgg;
    public GameObject DiemSinhGoc;
    public Transform StartPoint;
    float _bien_tg = 0f;
    Vector3 RandomMoveToPoint;
    void Start()
    {
        rgg = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > _bien_tg)
        {
            RandomMoveToPoint = new Vector3(
            Random.Range(StartPoint.position.x, StartPoint.position.x + 10)
            , Random.Range(StartPoint.position.y, StartPoint.position.y + 10), 0);
            GameObject _newDiem;
            _newDiem = Instantiate(DiemSinhGoc) as GameObject;
            _newDiem.transform.position = RandomMoveToPoint;
            _bien_tg = Time.time + 2f;
            Debug.Log("Bien:" + _bien_tg);
            Debug.Log("Time:" + Time.time);
            
        }
    }
}
