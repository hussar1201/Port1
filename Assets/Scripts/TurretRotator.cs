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
        //GetComponentInChildren 써야지 FindObjectOfType쓰면 프리펩 여러개가 맵에 있을 때 첫번째 프리펩 컴포넌트만 물어서 3놈이나
        //있어도 1놈밖에 안쏴제낌.


        bs = GetComponentInChildren<BulletSpawner>();
                
        timeSpawn = Random.Range(minTime, maxTime);                     
    }

    // Update is called once per frame
    void Update()
    {
        time_now += Time.deltaTime;                    

    }

    public void setTargetPos(Vector3 x)
    {
        targetPos = x;
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
