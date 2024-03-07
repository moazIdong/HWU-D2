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
        handleButtonState(buttonInfo, UpgradeEnum.SolarPanel);
        HideAllMenus();
    }


    public void HydroDam()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.HydroDam);
        handleButtonState(buttonInfo, UpgradeEnum.HydroDam);
        HideAllMenus();
    }
    public void WindTurbine()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.WindTurbine);
        handleButtonState(buttonInfo, UpgradeEnum.WindTurbine);
        HideAllMenus();
    }
    public void WasteManagment()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.WasteManagment);
        handleButtonState(buttonInfo, UpgradeEnum.WasteManagment);
        HideAllMenus();
    }
    public void CarbonCapture()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.CarbonCapture);
        handleButtonState(buttonInfo, UpgradeEnum.CarbonCapture);
        HideAllMenus();
    }
    public void Afforestation()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.Afforestation);
        handleButtonState(buttonInfo, UpgradeEnum.Afforestation);
        HideAllMenus();
    }
    public void GreenUrbanPlanning()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.GreenUrbanPlanning);
        handleButtonState(buttonInfo, UpgradeEnum.GreenUrbanPlanning);
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
    private void handleButtonState(UpgradeButtons buttonInfo, UpgradeEnum upgradeEnum)
    {
        if (buttonInfo.ButtonState)
        {
            buttonInfo.ButtonState = false;
            buttonInfo.CurrentButton.GetComponent<Image>().color = Color.red;
            EventManager.OnUpgrade.Invoke(CurrentContinent, upgradeEnum);
        }
        else
        {
            buttonInfo.ButtonState = true;
            buttonInfo.CurrentButton.GetComponent<Image>().color = Color.white;
            EventManager.OnDowngrade.Invoke(CurrentContinent, upgradeEnum);
        }
    }
}
