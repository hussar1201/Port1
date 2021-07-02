using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Bullet prefab;
    private Bullet liveFire;
    
    private float spawnRateMin = 0.5f;
    private float spawnRateMax = 3f;
    private Transform targetPos;
    private float timeAfterSpawn =0f;
    private float spawnRate = 0f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = FindObjectOfType<PlayerController>().transform;
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);       
    }

    // Update is called once per frame
    void Update()
    {
        /*
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            Fire();
        }
        */    
    }
      
    public void Fire()
    {
       
        liveFire = (Bullet)Instantiate<Bullet>(prefab, transform.position+new Vector3(0.03f,0.6f,2.2f), transform.rotation);
        liveFire.transform.LookAt(targetPos);
    }
    

}





