using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace logic
{

    public class TemperatureColorCode : MonoBehaviour
    {
        //SerializeField helps with initializing the variables inside unity editor directly and change them dynamically freely
        [SerializeField] Color[] ColorCodes; //initialzing an array of color type to hold the color codes of the continents
        
        internal Color GetColor(int index) //get the current color
        {
            if(index >= GetColorCodesCount())
            {
                return ColorCodes[GetColorCodesCount() - 1];
            }

            return ColorCodes[index];
        }
        internal int GetColorCodesCount() //returns the total of colors initialzed
        {
            return ColorCodes.Length;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}