using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed = 250f;
    private Rigidbody rb;
    private Transform firstPos;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }    
        
        
    public void AirStrike()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();

        Vector3 velocity = transform.forward * speed;
        rb.velocity = velocity;

        List<Enemy_Shilka> list_enemy;

        Enemy_Shilka[] arr = FindObjectsOfType<Enemy_Shilka>();

        if(arr!= null)
        {

            list_enemy = new List<Enemy_Shilka>(arr);
            int numOfEnemy = list_enemy.Count;
            int score = 10 * numOfEnemy;
            //Debug.Log(numOfEnemy);

            foreach(Enemy_Shilka enemy in list_enemy)
            {
                enemy.Die();
            }

            gm.AddScore(score);
        
        }


        Destroy(gameObject, 3f);

    }





}
