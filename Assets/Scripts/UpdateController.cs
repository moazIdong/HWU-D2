using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace logic
{
    public class UpdateController : MonoBehaviour
    {
        [SerializeField] private UpgradeData upgradeData;
        [SerializeField] private GameManager gameManager;
        // Start is called before the first frame update
        void Start()
        {
            EventManager.OnUpgrade.AddListener(OnUpgrade);
            EventManager.OnDowngrade.AddListener(OnDowngrade);
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnUpgrade(ContinentEnum currentContinent , UpgradeEnum upgradeOption)
        {
            UpgradeData.UpgradeDetails[] allOptionDetails = Array.Find(upgradeData.ContinentUpgradeValues, x => x.ContEnum == currentContinent).UpgDetails;
            UpgradeData.UpgradeDetails optionDetails = Array.Find(allOptionDetails, x => x.UpgradeOption == upgradeOption);
            print("Current Continent : " + currentContinent + "Current Upgrade : " + upgradeOption);
            //TODO : send event to UI to draw an Icon
            //TODO : send event to Temperature to update the temperature Value (due to applied Upgrade effect)
            Continent continent = gameManager.FindContinentClassByEnum(currentContinent);

            if(continent.GetContinetUpgradesCount(upgradeOption) < optionDetails.MaxAllowedUpgrade)
            {
                continent.UpdateContinetUpgrades(upgradeOption);
                Temperature temperature = continent.GetTemperatureInstance();
                temperature.SetTemperatureUpdate(optionDetails.TemperatureEffectValue);
                continent.GetIconHandelerInstance().UpdateIconStatus(upgradeOption , true);
            } 
            else
            {
                Debug.LogError("Max upgrade count is exceeding limit! " + upgradeOption + " continent: " + currentContinent);
            }
            
            //TODO : update Time_To_Lose here
        }
        private void OnDowngrade(ContinentEnum currentContinent, UpgradeEnum upgradeOption)
        {
            UpgradeData.UpgradeDetails[] allOptionDetails = Array.Find(upgradeData.ContinentUpgradeValues, x => x.ContEnum == currentContinent).UpgDetails;
            UpgradeData.UpgradeDetails optionDetails = Array.Find(allOptionDetails, x => x.UpgradeOption == upgradeOption);
            print("Current Continent : " + currentContinent + "Current Upgrade : " + upgradeOption);
            //TODO : send event to UI to draw an Icon
            //TODO : send event to Temperature to update the temperature Value (due to applied Upgrade effect)
            Continent continent = gameManager.FindContinentClassByEnum(currentContinent);

            if (continent.GetContinetUpgradesCount(upgradeOption) > 0)
            {
                continent.UpdateContinetDowngrades(upgradeOption);
                Temperature temperature = continent.GetTemperatureInstance();
                temperature.UnSetTemperatureUpdate(optionDetails.TemperatureEffectValue);
                continent.GetIconHandelerInstance().UpdateIconStatus(upgradeOption , false);
            }
            else
            {
                Debug.LogError("it's already Downgraded! => " + upgradeOption + " continent: " + currentContinent);
            }

            //TODO : update Time_To_Lose here
        }

    }
    
    public enum UpgradeEnum
    {
        SolarPanel,
        HydroDam,
        WindTurbine,
        WasteManagment,
        CarbonCapture,
        Afforestation,
        GreenUrbanPlanning
    }
}
