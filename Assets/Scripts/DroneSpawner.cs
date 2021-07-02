using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public Drone prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AirStrike()
    {

        Drone drone = (Drone)Instantiate<Drone>(prefab, transform.position,transform.rotation);  
        drone.AirStrike();
    }


}
