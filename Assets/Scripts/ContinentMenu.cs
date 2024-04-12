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
    Dictionary<UpgradeEnum, int> ContinentUpgradePointer;
    [Serializable]public class UpgradeButtons
    {
        public UpgradeEnum UpgEnum;
        public Button CurrentButton;
        public bool ButtonState; //true -> Upgrade \ False -> Downgrade
        //My Natural/Renewable Upgrade Data
    }
    private void UpdateButtonsState()
    {
        if(ContinentUpgradePointer == null)
        {
            return;
        }
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            int upgradeCount = 0;
            ContinentUpgradePointer.TryGetValue(upgradeButtons[i].UpgEnum, out upgradeCount);
            upgradeButtons[i].ButtonState = (upgradeCount > 0);
            handleButtonState(upgradeButtons[i],true);
        }
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
    internal void UpdateContinent(Continent continent)
    {
        CurrentContinent = continent.continent;
        ContinentUpgradePointer = continent.ContinentUpgradeData(CurrentContinent);
        UpdateButtonsState();
        naturalMenu.SetActive(false);
        renewableMenu.SetActive(false);
        mainUpgradeMenu.SetActive(true);
    }


    public void SolarPanel()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.SolarPanel);
        handleButtonState(buttonInfo);
        HideAllMenus();
    }

    public void HydroDam()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.HydroDam);
        handleButtonState(buttonInfo);
        HideAllMenus();
    }
    public void WindTurbine()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.WindTurbine);
        handleButtonState(buttonInfo);
        HideAllMenus();
    }
    public void WasteManagment()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.WasteManagment);
        handleButtonState(buttonInfo);
        HideAllMenus();
    }
    public void CarbonCapture()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.CarbonCapture);
        handleButtonState(buttonInfo);
        HideAllMenus();
    }
    public void Afforestation()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.Afforestation);
        handleButtonState(buttonInfo);
        HideAllMenus();
    }
    public void GreenUrbanPlanning()
    {
        UpgradeButtons buttonInfo = Array.Find(upgradeButtons, x => x.UpgEnum == UpgradeEnum.GreenUrbanPlanning);
        handleButtonState(buttonInfo);
        HideAllMenus();
    }

    private void HideAllMenus()
    {
        gameObject.SetActive(false);
        naturalMenu.SetActive(false);
        renewableMenu.SetActive(false);
        mainUpgradeMenu.SetActive(false);
    }
    private void handleButtonState(UpgradeButtons buttonInfo, bool skipInvoke = false)
    {
        if (buttonInfo.ButtonState)
        {
            buttonInfo.ButtonState = false;
            buttonInfo.CurrentButton.GetComponent<Image>().color = Color.red;
            if(skipInvoke == false)
            {
                EventManager.OnUpgrade.Invoke(CurrentContinent, buttonInfo.UpgEnum);
            }
        }
        else
        {
            buttonInfo.ButtonState = true;
            buttonInfo.CurrentButton.GetComponent<Image>().color = Color.white;
            if(skipInvoke == false)
            {
                EventManager.OnDowngrade.Invoke(CurrentContinent, buttonInfo.UpgEnum);
            }
        }
    }
}
