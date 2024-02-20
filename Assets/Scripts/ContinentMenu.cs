using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using logic;
using System;
using UnityEngine.UI;

public class ContinentMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainUpgradeMenu;
    [SerializeField] private GameObject naturalMenu;
    [SerializeField] private GameObject renewableMenu;
    [SerializeField] private UpgradeButtons[] upgradeButtons;
    ContinentEnum CurrentContinent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void UpdateContinent(Continent continent)
    {
        CurrentContinent = continent.continent;
        naturalMenu.SetActive(false);
        renewableMenu.SetActive(false);
        mainUpgradeMenu.SetActive(true);
    }
    public void OnRenewableMenuTrigger()
    {
        renewableMenu.SetActive(true);
        mainUpgradeMenu.SetActive(false);
        naturalMenu.SetActive(false);
    }
    public void OnNaturalMenuTrigger()
    {
        naturalMenu.SetActive(true);
        renewableMenu.SetActive(false);
        mainUpgradeMenu.SetActive(false);
    }
    public void SolarPanel()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.SolarPanel);
        if (buttonInfo.ButtonState)
        {
            buttonInfo.ButtonState = false;
            buttonInfo.CurrentButton.GetComponent<Image>().color = Color.red;
            EventManager.OnUpgrade.Invoke(CurrentContinent,UpgradeEnum.SolarPanel);
        }
        else
        {
            buttonInfo.ButtonState = true;
            buttonInfo.CurrentButton.GetComponent<Image>().color = Color.white;
            EventManager.OnDowngrade.Invoke(CurrentContinent, UpgradeEnum.SolarPanel);
        }
        HideAllMenus();
    }
    public void HydroDam()
    {
        EventManager.OnUpgrade.Invoke(CurrentContinent, UpgradeEnum.HydroDam);
        HideAllMenus();
    }
    public void WindTurbine()
    {
        EventManager.OnUpgrade.Invoke(CurrentContinent, UpgradeEnum.WindTurbine);
        HideAllMenus();
    }
    public void WasteManagment()
    {
        EventManager.OnUpgrade.Invoke(CurrentContinent, UpgradeEnum.WasteManagment);
        HideAllMenus();
    }
    public void CarbonCapture()
    {
        EventManager.OnUpgrade.Invoke(CurrentContinent, UpgradeEnum.CarbonCapture);
        HideAllMenus();
    }
    public void Afforestation()
    {
        EventManager.OnUpgrade.Invoke(CurrentContinent, UpgradeEnum.Afforestation);
        HideAllMenus();
    }
    public void GreenUrbanPlanning()
    {
        EventManager.OnUpgrade.Invoke(CurrentContinent, UpgradeEnum.GreenUrbanPlanning);
        HideAllMenus();
    }

    private void HideAllMenus()
    {
        gameObject.SetActive(false);
        naturalMenu.SetActive(false);
        renewableMenu.SetActive(false);
        mainUpgradeMenu.SetActive(false);
    }
    [Serializable]public class UpgradeButtons
    {
        public UpgradeEnum UpgEnum;
        public Button CurrentButton;
        public bool ButtonState; //true -> Upgrade \ False -> Downgrade
        //My Natural/Renewable Upgrade Data
    }
}
