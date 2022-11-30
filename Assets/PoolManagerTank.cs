using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerTank : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]

    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int size;
    }
    public static PoolManagerTank Instance;
    public List<Pool> _pool;
    Dictionary<string, Queue<GameObject>> poolDictionary;

    public Transform Parent;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in _pool)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab,Parent);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            poolDictionary.Add(pool.name, objectpool);  
        }
    }
    public GameObject SpawmPool(string name, Vector3 position, Quaternion rotation)
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
