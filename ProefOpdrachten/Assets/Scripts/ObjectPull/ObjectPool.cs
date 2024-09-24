using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private static ObjectPool pool;
    private int minimumInstances = 10;
    private List<GameObject> pools = new List<GameObject>();

    private ObjectPool()
    {
    }
    
    public static ObjectPool GetObjectPool()
    {
        if (ObjectPool.pool == null)
        {
            pool = new ObjectPool();
        }
        return pool;
    }

    public void InstantiateMinimun()
    {
        for (int i = 0; i < minimumInstances; i++)
        {
            MakeObject();
        }
    }
    
    public GameObject FreeObject()
    {
        if (pools.Count > 0)
        {
            GameObject objectToFree = pools[0];
            objectToFree.SetActive(true);
            pools.Remove(objectToFree);
            return objectToFree;
        }
        else
        {
            GameObject objectToFree = MakeObject();
            return objectToFree;
        }
    }

    public void acquiredObject(GameObject objectToGet)
    {
        objectToGet.SetActive(false);
        pools.Add(objectToGet);
    }

    public GameObject MakeObject()
    {
        GameObject Object = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
        Object.SetActive(false);
        pools.Add(Object);
        Object.AddComponent<ObjectLogic>();
        Object.AddComponent<Rigidbody>();
        Object.GetComponent<Rigidbody>().useGravity = false;
        return Object;
    }
}
