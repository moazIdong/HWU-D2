using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace logic
{
    public class Temperature : MonoBehaviour
    {
        //SerializeField helps with initializing the variables inside unity editor directly and change them dynamically freely
        [SerializeField]internal int LOW_TEMPERATURE = 25;
        [SerializeField]internal int MAX_TEMPERATURE = 40;
        [SerializeField]int TIME_TO_LOSE = 45;

        bool isGameOver = false;
        float timer = 0;
        float waitTime = 1;
        internal float current_temperature;
        internal float temperature_per_sec;
        float temperature_update;
        ContinentEnum continentName;

        internal void SetContinent(ContinentEnum continent)
        {
            continentName = continent;
        }
        public void UnSetTemperatureUpdate(float optionTemperature)
        {
            temperature_update -= optionTemperature;
        }
        public void SetTemperatureUpdate(float optionTemperature)
        {
            temperature_update += optionTemperature;
        }


        //Start is called before the first frame update
        void Awake()
        {
            current_temperature = LOW_TEMPERATURE; //initialize the starting temperature
            temperature_per_sec = (float)(MAX_TEMPERATURE - LOW_TEMPERATURE) / TIME_TO_LOSE; //Equation to calculate increase in temperature per 
            temperature_update = 0;
        }
        void Start()
        {
            EventManager.OnGameOver.AddListener(OnGameOver);
        }

        private void OnGameOver(ContinentEnum contient, int temperatureValue)
        {
            isGameOver = true;
        }

        //Update is called once per frame
        void Update()
        {
            if (isGameOver == true)
            {
                return;
            }
            //Check if game time have exceeded beyond 1 second.
            if (timer > waitTime)
            {
                timer = timer - waitTime; //Remove the recorded 1 seconds.
                if (current_temperature >= MAX_TEMPERATURE)
                {

                    EventManager.OnGameOver?.Invoke(continentName, (int)current_temperature);
                    isGameOver = true;
                    return;
                }
                else
                {
                    current_temperature += temperature_per_sec;
                    current_temperature -= temperature_update; //current_temperature = current_temperature - temperature_update
                }
            }
            timer += Time.deltaTime; //updates the game time
        }

        
    }
}