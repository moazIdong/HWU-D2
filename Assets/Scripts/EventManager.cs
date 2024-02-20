using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using logic;

public class EventManager : MonoBehaviour
{
    public static UnityEvent<ContinentEnum, int> OnGameOver;
    public static UnityEvent<int> OnGameStart;
    public static UnityEvent OnGameWin;
    public static UnityEvent<ContinentEnum,UpgradeEnum> OnUpgrade;
    public static UnityEvent<ContinentEnum, UpgradeEnum> OnDowngrade;

    void Awake()
    {
        if(OnGameOver == null)
        {
            OnGameOver = new UnityEvent<ContinentEnum, int>();
        }

        if (OnGameStart == null)
        {
            OnGameStart = new UnityEvent<int>();
        }

        if (OnGameWin == null)
        {
            OnGameWin = new UnityEvent();
        }
        if (OnUpgrade == null)
        {
            OnUpgrade = new UnityEvent<ContinentEnum, UpgradeEnum>();
        }
        if (OnDowngrade== null)
        {
            OnDowngrade = new UnityEvent<ContinentEnum, UpgradeEnum>();
        }
    }
    /* How to use this event Manager
    if (OnGameOver != null)
     OnGameOver();
    */

}
