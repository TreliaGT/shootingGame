﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    Vector3 inputVector;
    public float movespeed = 8f;
    public float gravity = -20f;
    CharacterController controller;

    [Header("Looking")]
    public Transform lookCamera;
    public float sensitivityx = 15f;
    public float sensitivityy = 15f;
    public float minY = -90;
    public float maxY = 90;
    float currentYrolation;
    Vector2 aimVector;


    [Header("Shooting")]
    public float shootrange = 500f;
    public LayerMask shootMask;
    public float firerate = 0.1f;
    public bool firing = false;
    public Transform muzzle;
    public GameObject HitEffectPrefab;
    public GameObject BulletPrefab;
    public GameObject MuzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        getinput();
        Move();
        Look();
    }

    void getinput()
    {
        //x local right and left 
        //y local up and down
        //z local forward and back
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");
        aimVector.x = Input.GetAxis("Mouse X");
        aimVector.y = Input.GetAxis("Mouse Y");
        if (Input.GetButtonDown("Fire1") && !firing)
        {
            Shoot();
        }
    }

    void Move()
    {
        Vector3 moveVector = transform.TransformDirection(inputVector.normalized);
        moveVector *= movespeed;
        moveVector.y = gravity;
        moveVector *= Time.deltaTime;
        controller.Move(moveVector);
    }

    void Look()
    {
        transform.Rotate(transform.up, aimVector.x * sensitivityx);
        currentYrolation += aimVector.y * sensitivityy;

        currentYrolation = Mathf.Clamp(currentYrolation, minY , maxY);
        lookCamera.eulerAngles = new Vector3(-currentYrolation , lookCamera.eulerAngles.y, lookCamera.eulerAngles.z);
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, muzzle.position, Quaternion.identity, muzzle).transform.forward = muzzle.forward;
        RaycastHit hit;
        if (Physics.Raycast(lookCamera.position, lookCamera.forward, out hit, shootrange, shootMask))
        {
            // print(hit.point);
            // print(hit.transform.gameObject.name);  
           
            Instantiate(HitEffectPrefab, hit.point, Quaternion.identity).transform.forward = hit.transform.TransformDirection(hit.normal);
        }
        Instantiate(MuzzleFlash, muzzle.position, Quaternion.identity, muzzle).transform.forward = muzzle.forward;
        StartCoroutine(FireRoute());
    }

    IEnumerator FireRoute()
    {
        firing = true;
        yield return new WaitForSeconds(firerate);
        firing = false;
    }
}
