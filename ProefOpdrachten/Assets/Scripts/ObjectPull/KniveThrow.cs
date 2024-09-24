using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KniveThrow : MonoBehaviour
{
    public bool called = false;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0)){

            throwKnive();
            Debug.Log("check");
        }
    }
    public void throwKnive(){
        GameObject Knive = ObjectPool.GetObjectPool().FreeObject();
        if (Knive != null){
            Knive.transform.rotation = gameObject.transform.rotation;
            Knive.GetComponent<Rigidbody>().velocity = transform.forward * 100;            
        }
    }
}
