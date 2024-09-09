using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class BulletPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static BulletPooler Instance;
    
    // When script is turned on
    private void Awake()
    {
        Instance = this;
    }
    
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    // On game start
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> poolObject = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                poolObject.Enqueue(obj);
            }
            
            poolDictionary.Add(pool.tag, poolObject);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool tag: " + tag + " not found");
            return null;
        }
        
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        poolDictionary[tag].Enqueue(objectToSpawn);
        
        return objectToSpawn;
    }
    
}
