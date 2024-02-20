using System;
using System.Collections;
using System.Collections.Generic;
using logic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UpgradePerContinent", order = 1)]
public class UpgradeData : ScriptableObject
{

    public ContinentsRefrence[] ContinentUpgradeValues;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Serializable]public struct ContinentsRefrence
    {
        public ContinentEnum ContEnum;
        public UpgradeDetails[] UpgDetails;
        //My Natural/Renewable Upgrade Data
    }
    [Serializable]public struct UpgradeDetails
    {
        public UpgradeEnum UpgradeOption;
        public float TemperatureEffectValue;
        public int UpdateTimeToLoseValue;
        public int MaxAllowedUpgrade;
        public int UpgradeCost;
        public int UpgradeRefund;
    }

}
