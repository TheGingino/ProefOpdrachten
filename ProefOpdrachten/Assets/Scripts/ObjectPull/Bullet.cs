using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private Vector3 mousePos;
    public Transform transform;
    private Camera mainCam;
    [SerializeField]private GameObject bullet;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0,0,rotZ);
        Instantiate(bullet, transform.transform.position, quaternion.identity);
        bullet.transform.position = bullet.transform.forward * (speed * Time.deltaTime);
    }
}
