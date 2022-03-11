using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPooler : MonoBehaviour
{

    [System.Serializable]
    private class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static AsteroidPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> poolDict;
    void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDict.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        if (!poolDict.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToSpawn = poolDict[tag].Dequeue();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if(pooledObj != null)
        {
            pooledObj.OnAsteroidSpawn();
        }
        poolDict[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

}
