using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy_Shilka : MonoBehaviour
{
    private Rigidbody rb;
    private Transform target;
    private TurretRotator turretRotator;
    private Vector3 distance;
    public float speed_move = 30f; //적 이동 속도 조정용 변수
        
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        turretRotator = GetComponentInChildren<TurretRotator>();
        target = FindObjectOfType<PlayerController>().transform;
        distance = new Vector3(0f, 0f, 0f);
    }
        
    void Update()
    {
        //플레이어 - 적의 거리 계산 후,
        distance = target.position - transform.position;
        distance.y = 0f;

        turretRotator.setTargetPos(distance);
        transform.LookAt(distance.normalized);
        turretRotator.transform.LookAt(distance.normalized);

        //거리에 따라 적이 취하는 행동을 결정
        if (distance.magnitude > 140f)
            rb.velocity = Vector3.zero;
        else if (distance.magnitude > 100f)
            rb.velocity = distance.normalized * speed_move;
        else
        {
            turretRotator.Fire();
            rb.velocity = Vector3.zero;
        }
    }

    public void Die()
    {
        Destroy(gameObject, 0.8f);
    }
}

        


