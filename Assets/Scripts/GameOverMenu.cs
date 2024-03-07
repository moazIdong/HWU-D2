using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI continentDetails;
    [SerializeField] private TextMeshProUGUI temperatureDetails;
    // Start is called before the first frame update
    public void UpdateText(string continent, string temperature)
    {
        continentDetails.text = continent;
        temperatureDetails.text = temperature + " °C";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
