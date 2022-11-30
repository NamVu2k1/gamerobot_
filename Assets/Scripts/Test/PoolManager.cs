using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int size;
    }
    public static PoolManager Instance;
    public List<Pool> _pool;
    Dictionary<string, Queue<GameObject>> poolDictionary;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in _pool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.name, objectPool);
        }
    }
    public GameObject SpawmPool(string name, Vector3 position, Quaternion rotation)
    {
        GameObject objSpawm1 = poolDictionary[name].Dequeue();
        objSpawm1.SetActive(true);
        objSpawm1.transform.position = position;
        objSpawm1.transform.rotation = rotation;
        poolDictionary[name].Enqueue(objSpawm1);
        return objSpawm1;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
