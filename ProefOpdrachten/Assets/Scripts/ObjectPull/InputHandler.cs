using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private void Start()
    { 
        ObjectPool.GetObjectPool().InstantiateMinimun();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("ik leef");
            GameObject gameObject = ObjectPool.GetObjectPool().FreeObject();
            this.gameObject.transform.position = transform.position;
            this.gameObject.transform.rotation = transform.rotation;
        }
    }
}
