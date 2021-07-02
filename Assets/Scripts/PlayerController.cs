/* 빈 오브젝트인 Player의 하위 오브젝트로 Heli를 넣음으로서, 
 * RigidBody 컴포넌트 설정에서 Y축 방향 이동을 금지하지 않고
 * 추후 필요시 Y축 이동이 가능하게되어 확장성이 넓어진 코드
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    HeliController player_Huey; // 하위 오브젝트인 헬리콥터 인스턴스용 변수
    public float speed = 50f;
    public float rotationSpeed = 1f;
    Rigidbody rb;
    private int HP = 100;
    float xInput, zInput;
    float xRotation = 0.0f; // yaw 누적용
    private DroneSpawner droneSpawner;
    private float time_droneRespawnInterval = 30f;
    private float time_droneRespawnTime = 30f;


    // Start is called before the first frame update
    void Start()
    {

        droneSpawner = FindObjectOfType<DroneSpawner>();
        
        player_Huey = GetComponentInChildren<HeliController>(); //하위객체 중 헬기 인스턴스 검색.
        rb = GetComponent<Rigidbody>(); //빈 객체 Player용 rb
        

    }

    public float get_time_droneRespawnTime()
    {
        return time_droneRespawnTime;
    }

    public int getHP()
    {
        return HP;
    }

    void Die()
    {
        GameManager.GameOver = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
                
        time_droneRespawnTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (time_droneRespawnTime <= 0) 
            { 
                droneSpawner.AirStrike();
                time_droneRespawnTime = time_droneRespawnInterval;
            }

        }


        Quaternion rotation_Y;

        if (Input.GetKey(KeyCode.E))
        {
            xRotation += rotationSpeed;
            //Debug.Log(xRotation);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            xRotation-= rotationSpeed;
            //Debug.Log(xRotation);
        }
        

        zInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");
        rotation_Y = Quaternion.Euler(0f, xRotation, 0f);
        transform.rotation = rotation_Y;

        player_Huey.setPitch(zInput, xRotation);

        if (xInput == 0f) rb.velocity = (transform.forward * speed * zInput);
        else rb.velocity = (transform.forward * speed * zInput) + (transform.right * speed / 5 * xInput);

        if (xInput == 0f && zInput == 0) rb.velocity = new Vector3(0, 0, 0);


        if (xRotation != 0.0f) xRotation %= 360f;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
                
        if(other.tag == "Bullet")
        {
            HP -= 10;
            if (HP == 0) Die();
        }



    }


}
