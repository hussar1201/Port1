using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShilkaSpawner : MonoBehaviour
{
    public Enemy_Shilka shilka;


    // Start is called before the first frame update
    void Start()
    {
        makeEnemy();
    }


    public void makeEnemy()
    {
        Instantiate(shilka);
    }


  
}
