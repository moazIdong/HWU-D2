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

        bool isGameTimerStop = false; //note
        float timer = 0;
        float waitTime = 1;
        internal float current_temperature;
        internal float temperature_per_sec;
        float temperature_update;
        int temperature_levels = 5;
        ContinentEnum continentName;

        //Start is called before the first frame update
        void Awake()
        {
            current_temperature = LOW_TEMPERATURE; //initialize the starting temperature
            temperature_per_sec = (float)(MAX_TEMPERATURE - LOW_TEMPERATURE) / TIME_TO_LOSE; //Equation to calculate increase in temperature per 
            print("TEMPERATURE : " + temperature_per_sec + " CONTINENT : " + continentName);
            temperature_update = 0;
        }
        void Start()
        {
            EventManager.OnGameOver.AddListener(OnGameOver);
            EventManager.OnGameWin.AddListener(OnGameWon);
        }

        internal void SetContinent(ContinentEnum continent)
        {
            continentName = continent;
        }
        public void UnSetTemperatureUpdate(float optionTemperature, int optionTimeToLose)
        {
            temperature_update -= optionTemperature;
            if (optionTimeToLose > 0)
            {
                TIME_TO_LOSE -= optionTimeToLose;
                temperature_per_sec = (float)(MAX_TEMPERATURE - LOW_TEMPERATURE) / TIME_TO_LOSE; //Equation to calculate increase in temperature per 
                print("TEMPERATURE : " + temperature_per_sec + " CONTINENT : " + continentName);
            }
        }
        public void SetTemperatureUpdate(float optionTemperature, int optionTimeToLose)
        {
            temperature_update += optionTemperature;
            if (optionTimeToLose > 0)
            {
                TIME_TO_LOSE += optionTimeToLose;
                temperature_per_sec = (float)(MAX_TEMPERATURE - LOW_TEMPERATURE) / TIME_TO_LOSE; //Equation to calculate increase in temperature per 
                print("TEMPERATURE : " + temperature_per_sec + " CONTINENT : " + continentName);
            }
            
        }


        private void OnGameWon()
        {
            isGameTimerStop = true;
        }

        private void OnGameOver(ContinentEnum contient, int temperatureValue) //note
        {
            isGameTimerStop = true;
        }

        public int GetCurrentTemperatureIndex()
        {
            int lowMaxDiffrence = MAX_TEMPERATURE - LOW_TEMPERATURE;
            int temperatureStep = lowMaxDiffrence / temperature_levels; //calculates the rate of temperature value which the game uses to switch color code of the country
            int temperatureIndex = (((int)current_temperature) - LOW_TEMPERATURE) / temperatureStep; //mentions which index to use in colorCodes array
            return temperatureIndex;
        }

        //Update is called once per frame
        void Update()
        {
            if (isGameTimerStop == true) //note
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
                    isGameTimerStop = true;
                    return;
                }
                else
                {
                    current_temperature += temperature_per_sec;
                    current_temperature -= temperature_update; //current_temperature = current_temperature - temperature_update
                    CheckCurrentTemperatureBoundaries();
                }
            }
            timer += Time.deltaTime; //updates the game time
        }

        private void CheckCurrentTemperatureBoundaries()
        {
            if (current_temperature < LOW_TEMPERATURE)
            {
                current_temperature = LOW_TEMPERATURE;
            }
        }
    }
}