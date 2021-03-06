using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
}
public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> instancedObjects;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        instancedObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject objectToPool = Instantiate(item.objectToPool);
                objectToPool.SetActive(false);
                instancedObjects.Add(objectToPool);
            }
        }
    }

    public GameObject GetPoolObject(string tag)
    {
        for (int i = 0; i < instancedObjects.Count; i++)
        {
            if(!instancedObjects[i].activeInHierarchy && instancedObjects[i].CompareTag(tag))
            {
                return instancedObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.CompareTag(tag))
            {
                GameObject objectToAddToPool = Instantiate(item.objectToPool);
                objectToAddToPool.SetActive(false);
                instancedObjects.Add(objectToAddToPool);
                return objectToAddToPool;
            }
        }
        return null;
    }
}
