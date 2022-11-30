using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]

    public class item
    {
        public string name;
        public GameObject prefab;
        public int size;
    }
    public static spawn Instance;
    public List<item> Item;
    Dictionary<string, Queue<GameObject>> poolDictionary;
    

    public Transform Parent;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (item star in Item)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for (int i = 0; i < star.size; i++)
            {
              

                GameObject obj = Instantiate(star.prefab, Parent);
                
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            poolDictionary.Add(star.name, objectpool);
        }
    }
    public GameObject SpawmPool1(string name, Vector3 position, Quaternion rotation)
    {
        if (GetComponentsInChildren<Transform>().GetLength(0) <=5)
        {
            GameObject objSpawm = poolDictionary[name].Dequeue();
            objSpawm.SetActive(true);
            objSpawm.transform.position = position;
            objSpawm.transform.rotation = rotation;
            poolDictionary[name].Enqueue(objSpawm);
             return objSpawm;
        }
        else
        {
            return null;
        }
        
      

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.up*Time.deltaTime);
    }
}
