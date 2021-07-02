/*첫번째 시도(PlayerController 및 HeliController) 하다가 잘 안되서 
 * Y축 유니티 설정에서 고정해서 못써버리게 해버리고, 보다 쉬운 방식으로 짜보려 한 코드
 * 여튼 1안 2안 현재는 다 의도한대로 작동 됨(2021.04.10.)
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliVerOne : MonoBehaviour
{
    public float speed = 100f;
    Rigidbody rb;
    float xInput, zInput;
    float yawRotation = 0.0f; // Z축 회전 각도 누적을 위한 변수.

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation_X, rotation_Y, rotation;

        if (Input.GetKey(KeyCode.D)) // D키 눌러서 시계방향 회전 시, Z축 회전각 +1씩 증가
        {
            yawRotation++;
            //Debug.Log(yawRotation);
        }

        if (Input.GetKey(KeyCode.A)) // A키 눌러서 반시계방향 회전 시, Z축 회전각 -1씩 차감
        {
            yawRotation--;
            //Debug.Log(yawRotation);
        }

        zInput = Input.GetAxis("Vertical"); // 헬기 전후 기동을 위한 입력

        //2개 축 이상 동시 각도변환 표현할 경우에는 Quaternion 사용이 필수적.
        //transform.Rotate()로 해결 안 나니 사용법 숙지할 것
       
        rotation_Y = Quaternion.Euler(0f, yawRotation, 0f); // Y축 회전값(Yaw) 입력
        rotation_X = Quaternion.Euler(15 * zInput, 0f, 0f); // 전후 기동 시 기체가 앞뒤로 숙여지는 표현을 위해 X축 회전값(Pitch) 입력
        rotation = rotation_X * rotation_Y; // 둘다 곱해 준후
        transform.rotation = rotation; // 대입

        rb.velocity = transform.forward * speed * zInput; // 전후 이동

        if (yawRotation != 0.0f) yawRotation %= 360f; //왠만해선 안 일어나겠지만, 만약을 위한 오류 대비 처리...

    }



}


