using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace logic
{
    public class Continent : MonoBehaviour
    {
        //SerializeField helps with initializing the variables inside unity editor directly and change them dynamically freely
        public ContinentEnum continent;
        [SerializeField]private TextMeshProUGUI temperatureCounter;
        [SerializeField]private TextMeshProUGUI continentName;
        [SerializeField]private TemperatureColorCode colorCode;
        private Temperature temperature;
        private RewardSystem rewardSystem;
        private IconHandeler iconHandeler;
        private Dictionary<UpgradeEnum, int> continentUpgrades = new Dictionary<UpgradeEnum, int>();

        float timer = 0;
        float waitTime = 1;

        // Start is called before the first frame update
        void Start()
        {
            iconHandeler = GetComponentInChildren<IconHandeler>();
            rewardSystem = GetComponent<RewardSystem>();
            rewardSystem.SetContinent(continent);
            temperature = GetComponent<Temperature>();
            temperature.SetContinent(continent);
            temperatureCounter.text = temperature.current_temperature.ToString() + " °C"; //converts the current_temperature variable from float to string
        }
        internal void LosingTempEffect()
        {
            temperatureCounter.fontStyle = FontStyles.Bold;
            temperatureCounter.fontSize = 40;
            temperatureCounter.alignment = TextAlignmentOptions.Bottom;
        }
        internal void LosingNameEffect()
        {
            continentName.fontStyle = FontStyles.Bold;
            continentName.fontSize = 40;
            continentName.alignment = TextAlignmentOptions.Bottom;
        }
        internal void ResetFont()
        {
            temperatureCounter.fontStyle = FontStyles.Normal;
            temperatureCounter.fontSize = 28;
            temperatureCounter.alignment = TextAlignmentOptions.Top;
        }
        internal void UpdateContinetDowngrades(UpgradeEnum upgradeOption)
        {
            // reduces the count of upgrade option since the upgrde is being removed
                continentUpgrades[upgradeOption]--;
        }
        internal void UpdateContinetUpgrades(UpgradeEnum upgradeOption)
        {
            // The Add method throws an exception if the new key is
            // already in the dictionary.
            try
            {
                continentUpgrades.Add(upgradeOption, 1);
            }
            catch (ArgumentException)
            {
                continentUpgrades[upgradeOption]++;
            }
        }
        internal int GetContinetUpgradesCount(UpgradeEnum upgradeOption)
        {
            bool isUpgradeFound = continentUpgrades.TryGetValue(upgradeOption, out int value);
            if (isUpgradeFound)
            {
                return value;
            }
            else
            {
                return 0;
            }
        }


        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime; //updates the game time

            //Check if game time have exceeded beyond 1 second.
            if (timer > waitTime)
            {
                timer = timer - waitTime;//Remove the recorded 1 seconds.
                temperatureCounter.text = ((int)temperature.current_temperature).ToString() + " °C"; //updates the temperature counter
                ColorContinent();
            }
        }

        private void ColorContinent()
        {
            /* 
            - low temperature = 20
            - max temperature = 40
            - Length of colorArray = 5
             [] Diffrence In Temperature = (low-max) 40-20 == 20
             [] TemperatureStep = (Diffrence In Temperature / Length Of colorArray) 20/5 == 4
             [] currentTemperature = (25-20)/4  ((current Temperature-Low Temperature)/TemperatureStep)
            _________________________________________________________________________________

            20-24 Green 10
            25-28 Yellow 8 
            29-32 Light Orange 6
            33-36 Orange 4 
            37-40 Red 2
            */

            int temperatureIndex = temperature.GetCurrentTemperatureIndex();
            //print(colorIndex + " Temp :" + temperature.current_temperature); 
            gameObject.GetComponent<SpriteRenderer>().color = colorCode.GetColor(temperatureIndex); //changes color of continent

        }
        public Temperature GetTemperatureInstance()
        {
            return temperature;
        }
        public IconHandeler GetIconHandelerInstance()
        {
            return iconHandeler;
        }

    }
    public enum ContinentEnum
    {
        Asia,
        Africa,
        Europe,
        NA,
        SA,
        Australia,
        empty
    }
}

