using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using logic;
using System;

public class RewardSystem : MonoBehaviour
{
    bool isGameTimerStop = false;
    float timer = 0;
    [SerializeField]float waitTime = 5;
    private Temperature temperature;
    ContinentEnum continentName;
    
    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnGameOver.AddListener(OnGameOver);
        EventManager.OnGameWin.AddListener(OnGameWon);
        temperature = GetComponent<Temperature>(); //gets temperature
    }
    private void OnGameOver(ContinentEnum contient, int temperatureValue) 
    {
        isGameTimerStop = true;
    }
    private void OnGameWon()
    {
        isGameTimerStop = true;
    }

    internal void SetContinent(ContinentEnum continent)
    {
        continentName = continent;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isGameTimerStop == true)
        {
            return;
        }
        timer += Time.deltaTime; //updates the game time
        //Check if game time have exceeded beyond 1 second.
        if (timer > waitTime)
        {
            timer = timer - waitTime;//Remove the recorded 5 seconds.
            int temperatureIndex = temperature.GetCurrentTemperatureIndex();
            int rewardValue = Array.Find(DataCenter.Instance.upgradeData.ContinentUpgradeValues, x => x.ContEnum == continentName).Rewards[temperatureIndex];
            EventManager.OnRewardTick.Invoke(rewardValue);
        }
    }


}
