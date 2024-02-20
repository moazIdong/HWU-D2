using System;
using System.Collections;
using System.Collections.Generic;
using logic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private ContinentsRefrence[] Refrence;
    [SerializeField]private int countdownTime; //Countdown time in seconds
    [SerializeField]private GameObject GameWonMenu;
    [SerializeField]private GameObject GameLoseMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameWonMenu.SetActive(false);
        GameLoseMenu.SetActive(false);
        EventManager.OnGameOver.AddListener(OnGameOver);
        GameStart();
    }

    void GameStart()
    {
        EventManager.OnGameStart?.Invoke(countdownTime);
        EventManager.OnGameWin.AddListener(GameWin);
    }

    private void GameWin()
    {
        GameWonMenu.SetActive(true);
        print("Game Won");
    }

    private void OnGameOver(ContinentEnum continentName, int temperatureValue)
    {
        print("Game Over Initiated" + continentName);
        StartCoroutine(WaitAndGameOver(continentName, temperatureValue));
        Continent losingContinent = FindContinentClassByEnum(continentName);
        losingContinent.LosingTempEffect();
    }

    public Continent FindContinentClassByEnum(ContinentEnum continentName)
    {
        return Array.Find(Refrence, x => x.ContEnum == continentName).continentClass;
    }

    /*void OnDisable()
    {
        EventManager.OnGameOver.RemoveListener(OnGameOver);
    }*/

    IEnumerator WaitAndGameOver(ContinentEnum continentName, int temperatureValue)
    {
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(2);
        print("GameOver Screen: " + Time.time);
        GameLoseMenu.SetActive(true);
        GameLoseMenu.GetComponent<GameOverMenu>().UpdateText(continentName.ToString(), temperatureValue.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable] public struct ContinentsRefrence
{
    public ContinentEnum ContEnum;
    public Continent continentClass;
}

