using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameOver = false;
    public Text text_Score;
    public Text text_HP;
    public Text text_AirSupport;
    int score = 0;
    
    float droneRespawnTime;
    private PlayerController pc;


    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        droneRespawnTime = pc.get_time_droneRespawnTime();


    }

    // Update is called once per frame
    void Update()
    {
        int playerHP = pc.getHP();
        text_HP.text = ("HP : " + playerHP);

        if (playerHP == 0)
        {
            Debug.Log("Game Over");

        }


        droneRespawnTime  = pc.get_time_droneRespawnTime();
        
        if (droneRespawnTime > 0) 
        {
            text_AirSupport.text = ("Air Support Available in " + (int)droneRespawnTime +"s");
        }
        else
        {
            text_AirSupport.text = ("!!Call Air Support!!\n'SPACE'");
        }

    }


    public void AddScore(int killScore)
    {
        score += killScore;
        text_Score.text = ("Score : " + score);
    }


}

    



