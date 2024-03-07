using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using logic;
using System;
using TMPro;

public class PointsHandeler : MonoBehaviour
{
    public int GamePoints { get; private set; }
    [SerializeField] private TextMeshProUGUI gamePointsText;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnUpgrade.AddListener(OnUpgrade);
        EventManager.OnDowngrade.AddListener(OnDowngrade);
        EventManager.OnRewardTick.AddListener(OnRewardTick);
        GamePoints = DataCenter.Instance.upgradeData.StartingGamePoints;
        gamePointsText.text = GamePoints+" Points";
    }

    private void OnRewardTick(int reward)
    {
        GamePoints += reward;
        gamePointsText.text = GamePoints + " Points";
    }

    private void OnUpgrade(ContinentEnum currentContinent, UpgradeEnum upgradeOption)
    {
        UpgradeData.UpgradeDetails[] allOptionDetails = Array.Find(DataCenter.Instance.upgradeData.ContinentUpgradeValues, x => x.ContEnum == currentContinent).UpgDetails;
        UpgradeData.UpgradeDetails optionDetails = Array.Find(allOptionDetails, x => x.UpgradeOption == upgradeOption);
        GamePoints -= optionDetails.UpgradeCost;
        gamePointsText.text = GamePoints + " Points";
    }

    private void OnDowngrade(ContinentEnum currentContinent, UpgradeEnum upgradeOption)
    {
        UpgradeData.UpgradeDetails[] allOptionDetails = Array.Find(DataCenter.Instance.upgradeData.ContinentUpgradeValues, x => x.ContEnum == currentContinent).UpgDetails;
        UpgradeData.UpgradeDetails optionDetails = Array.Find(allOptionDetails, x => x.UpgradeOption == upgradeOption);
        GamePoints += optionDetails.UpgradeRefund;
        gamePointsText.text = GamePoints + " Points";
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
