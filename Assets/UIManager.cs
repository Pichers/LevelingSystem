using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text level;
    public Text size;
    public Text speed;
    public Text time;

    #region Win
    [Header("Win")]
    public Text congrats;
    public Text FinalTime;
   
    private DateTime initTime;
    #endregion

    private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        initTime = System.DateTime.Now;
        congrats.text = "";
        FinalTime.text = "";
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0){
            int timeDifference = (int) (System.DateTime.Now - initTime).TotalSeconds;

            level.text = "Level: " + playerController.GetLevel().ToString();
            size.text = "Size: " + playerController.GetSpeed().ToString();
            speed.text = "Speed: " + playerController.GetSize().ToString();
            time.text = "Time: " + timeDifference.ToString();

            if(playerController.IsMaxLevel()){
                Congrats(timeDifference);
            }
        }
        
    }
    void Congrats(int timeDifference){
        Time.timeScale = 0;

        congrats.text = "Congrats, You Won!!!";
        time.text = timeDifference.ToString();
        FinalTime.text = timeDifference.ToString() + " Seconds";
    }
}
