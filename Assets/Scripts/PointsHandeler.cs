using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using logic;
using System;
using TMPro;

public class PointsHandeler : MonoBehaviour
{
    [SerializeField] private UpgradeData upgradeData; //temporary
    [SerializeField] private int gamePoints;
    [SerializeField] private TextMeshProUGUI gamePointsText;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnUpgrade.AddListener(OnUpgrade);
        EventManager.OnDowngrade.AddListener(OnDowngrade);
        gamePointsText.text = gamePoints+" Points";
    }
    private void OnUpgrade(ContinentEnum currentContinent, UpgradeEnum upgradeOption)
    {
        UpgradeData.UpgradeDetails[] allOptionDetails = Array.Find(upgradeData.ContinentUpgradeValues, x => x.ContEnum == currentContinent).UpgDetails;
        UpgradeData.UpgradeDetails optionDetails = Array.Find(allOptionDetails, x => x.UpgradeOption == upgradeOption);
        gamePoints -= optionDetails.UpgradeCost;
        gamePointsText.text = gamePoints + " Points";
    }

    private void OnDowngrade(ContinentEnum currentContinent, UpgradeEnum upgradeOption)
    {
        UpgradeData.UpgradeDetails[] allOptionDetails = Array.Find(upgradeData.ContinentUpgradeValues, x => x.ContEnum == currentContinent).UpgDetails;
        UpgradeData.UpgradeDetails optionDetails = Array.Find(allOptionDetails, x => x.UpgradeOption == upgradeOption);
        gamePoints += optionDetails.UpgradeRefund;
        gamePointsText.text = gamePoints + " Points";
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
