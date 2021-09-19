using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotator : MonoBehaviour
{
    private BulletSpawner bs;
    private Vector3 targetPos;
    private float maxTime = 0.3f;
    private float minTime = 0.05f;
    private float timeSpawn = 0f;
    private float time_now = 0f;

    // Start is called before the first frame update
    void Start()
    {
       bs = GetComponentInChildren<BulletSpawner>();
                
        timeSpawn = Random.Range(minTime, maxTime);                     
    }

    // Update is called once per frame
    void Update()
    {
        time_now += Time.deltaTime;                    
    }

    public void setTargetPos(Vector3 pos_player)
    {
        targetPos = pos_player;
        return;
    }

    public void Fire()
    {
        if (time_now >= timeSpawn && !GameManager.GameOver)
        {          
            timeSpawn = Random.Range(minTime, maxTime);
            time_now = 0f;                       
            bs.Fire();
        }       
    }





}
