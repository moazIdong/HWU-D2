using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameWonMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameScore;
    // Start is called before the first frame update
    public void UpdateText(int points)
    {
        gameScore.text = "Points : " + points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
