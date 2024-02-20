using logic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconHandeler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void UpdateIconStatus(UpgradeEnum upgrade, bool activate = true)
    {
        IconType[] iconsArray = GetComponentsInChildren<IconType>(true);
        Array.Find<IconType>(iconsArray, x => x.UpgradeIconType == upgrade).gameObject.SetActive(activate);
        //UpgradeData.UpgradeDetails[] allOptionDetails = Array.Find(upgradeData.ContinentUpgradeValues, x => x.ContEnum == currentContinent).UpgDetails;

    }

}
