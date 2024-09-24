using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class ObjectLogic : MonoBehaviour
{
    public float timer =3;
    public float timeAlive = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeAlive;
            ObjectPool.GetObjectPool().acquiredObject(this.gameObject);
        }
    }
}
