using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerStar : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]

    public class Star
    {
        public string name;
        public GameObject prefab;
        public int size;
    }
    public static PoolManagerStar Instance;
    public List<Star> _star;
    Dictionary<string, Queue<GameObject>> poolDictionary;

    public Transform Parent;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Star star in _star)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for(int i = 0; i < star.size; i++)
            {
                float ran = Random.Range(0.5f, 1f);
             
                GameObject obj = Instantiate(star.prefab, Parent);
                obj.transform.localScale = new Vector3(ran, ran, ran);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            poolDictionary.Add(star.name, objectpool);
        }
    }
    public GameObject SpawmPool1(string name, Vector3 position, Quaternion rotation)
    {
        GameObject objSpawm = poolDictionary[name].Dequeue();
        objSpawm.SetActive(true);
        objSpawm.transform.position = position;
        objSpawm.transform.rotation = rotation;
        poolDictionary[name].Enqueue(objSpawm);
        return objSpawm;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
