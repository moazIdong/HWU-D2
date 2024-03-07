using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using logic;
using System;

public class RewardSystem : MonoBehaviour
{
    float timer = 0;
    [SerializeField]float waitTime = 5;
    private Temperature temperature;
    ContinentEnum continentName;
    
    // Start is called before the first frame update
    void Start()
    {
        temperature = GetComponent<Temperature>(); //gets temperature
    }

    internal void SetContinent(ContinentEnum continent)
    {
        continentName = continent;
    }

    // Update is called once per frame
    void Update()
    {
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
