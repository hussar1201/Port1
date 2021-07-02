using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy_Shilka : MonoBehaviour
{
    private Rigidbody rb;
    private Transform target;
    private TurretRotator turretRotator;
                
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        turretRotator = GetComponentInChildren<TurretRotator>();
        target = FindObjectOfType<PlayerController>().transform;
              
    }

    // Update is called once per frame
    void Update()
    {
  
        Vector3 distance =  target.position - transform.position;
        distance.y = 0f;
       
        Vector3 dest = new Vector3(distance.x, 0f, distance.z);
        dest = dest.normalized;

        turretRotator.setTargetPos(dest);


        if (distance.magnitude > 140f)
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.LookAt(dest);
            turretRotator.transform.LookAt(dest);
        }
        else if (distance.magnitude > 100f)
        {
            transform.LookAt(dest);
            turretRotator.transform.LookAt(dest);
            rb.velocity = dest * 30;

        }
        else if (distance.magnitude >= 0.0f)
        {
            
            turretRotator.transform.LookAt(dest);
            turretRotator.Fire();                        

            rb.velocity = new Vector3(0, 0, 0);


        }

    }


    public void Die()
    {
        Destroy(gameObject,0.8f);
    }


        
}

